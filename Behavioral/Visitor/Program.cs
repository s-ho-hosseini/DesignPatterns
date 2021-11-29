using System;
using System.Collections.Generic;

namespace Visitor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var document = new HtmlDocument();
            document.add(new HeadingNode());
            document.add(new AnchorNode());
            document.execute(new HiglightOperation());
        }
    }


    public interface HtmlNode
    {
        void execute(Operation operation);
    }

    public interface Operation
    {
        void apply(HeadingNode heading);
        void apply(AnchorNode anchor);
    }

    public class HeadingNode : HtmlNode
    {
        public void execute(Operation operation)
        {
            operation.apply(this);
        }
    }

    public class AnchorNode : HtmlNode
    {
        public void execute(Operation operation)
        {
            operation.apply(this);
        }

    }

    public class HtmlDocument
    {
        private List<HtmlNode> nodes = new List<HtmlNode>();

        public void add(HtmlNode node)
        {
            nodes.Add(node);
        }

        public void execute(Operation operation)
        {
            foreach (var node in nodes) node.execute(operation);
        }
    }

    public class HiglightOperation : Operation
    {
        public void apply(HeadingNode heading)
        {
            Console.WriteLine("highlight-heading");
        }

        public void apply(AnchorNode anchor)
        {
            Console.WriteLine("highlight-anchor");

        }
    }
}