using System.IO;

namespace Solid_Master.Facade
{
    internal class Scanner
    {
        public Scanner(StreamReader input)
        {
        }
    }

    internal class BytecodeStream
    {
    }

    internal class Node
    {
    }

    internal class ProgramNode
    {
        public void Traverse(RiscCodeGenerator generator)
        {
        }
    }

    internal class ProgramNodeBuilder
    {
        public ProgramNode GetRootNode()
        {
            return null;
        }
    }

    internal class Parser
    {
        public void Parse(Scanner scanner, ProgramNodeBuilder builder)
        {
        }
    }

    internal class RiscCodeGenerator
    {
        public RiscCodeGenerator(BytecodeStream output)
        {
        }
    }

    internal class Compiler
    {
        public static void Main()
        {
            new Compiler().Compile(null, null);
        }

        public virtual void Compile(StreamReader input, BytecodeStream output)
        {
            var scanner = new Scanner(input);
            var builder = new ProgramNodeBuilder();
            var parser = new Parser();

            parser.Parse(scanner, builder);

            var generator = new RiscCodeGenerator(output);
            var parseTree = builder.GetRootNode();
            parseTree.Traverse(generator);
        }
    }
}