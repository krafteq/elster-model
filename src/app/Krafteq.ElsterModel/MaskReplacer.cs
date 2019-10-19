namespace Krafteq.ElsterModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using LanguageExt;

    class MaskReplacer
    {
        internal readonly string inputMask;
        internal readonly string outputMask;

        Option<int>[] replacements;

        public MaskReplacer(string inputMask, string outputMask)
        {
            this.inputMask = inputMask;
            this.outputMask = outputMask;

            this.CreateReplacements();
        }

        void CreateReplacements()
        {
            var maskPositions = new Queue<int>[26];
            
            for (var i = 0; i < this.inputMask.Length; i++)
            {
                this.ExtractVariable(this.inputMask[i])
                    .IfSome(variable =>
                    {
                        if (maskPositions[variable] == null) 
                            maskPositions[variable] = new Queue<int>();
                        
                        maskPositions[variable].Enqueue(i);
                    });
            }

            this.replacements = new Option<int> [this.outputMask.Length];

            for (var i = 0; i < this.outputMask.Length; i++)
            {
                this.ExtractVariable(this.outputMask[i])
                    .IfSome(variable =>
                    {
                        if (!maskPositions[variable].Any())
                            throw new InvalidOperationException("OutputMask is inconsistent to its InputMask");

                        var position = maskPositions[variable].Dequeue();
                        this.replacements[i] = position;
                    });
            }
        }

        Option<int> ExtractVariable(char c)
        {
            if (c >= 'A' && c <= 'Z')
                return c - 'A';
            return Prelude.None;
        }
        
        public string Replace(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            if (!this.IsValidInput(input))
                throw new InvalidOperationException(
                    $"Input is not valid for given input mask");

            return new string(this.replacements.Select((replacement, ind) => replacement.Match(
                r => input[r],
                () => this.outputMask[ind]
            )).ToArray());
        }

        public bool IsValidInput(string input)
        {
            if (input.Length != this.inputMask.Length)
                return false;

            for (var i = 0; i < input.Length; i++)
            {
                if (!this.ExtractVariable(this.inputMask[i])
                    .Map(x => true)
                    .IfNone(() => this.inputMask[i] == input[i]))
                    return false;
            }

            return true;
        }
    }
}