using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public static class ExpressionTool
    {
        public static string TransferExpressionType(this ExpressionType expressionType)
        {
            string type = "";
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    type = "="; break;
                case ExpressionType.GreaterThanOrEqual:
                    type = ">="; break;
                case ExpressionType.LessThanOrEqual:
                    type = "<="; break;
                case ExpressionType.NotEqual:
                    type = "!="; break;
                case ExpressionType.AndAlso:
                    type = "And"; break;
                case ExpressionType.OrElse:
                    type = "Or"; break;
            }
            return type;
        }
    }

    public class ExpressionResolver : ExpressionVisitor
    {
        private StringBuilder s;

        public string Result { get { return s.ToString(); } }

        public ExpressionResolver() {
            s = new StringBuilder { };
        }

        public override Expression Visit(Expression node) {
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node) {

            s.Append("(");

            Visit(node.Left);

            s.Append(node.NodeType.TransferExpressionType());

            Visit(node.Right);

            s.Append(")");
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            s.Append($"{node.Member.Name}");
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            s.Append($"{node.Value}");
            return node;
        }
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            s.Append($"{node.Method.Name}");
            return node;
        }
        
    }
}
