using System;
using System.Linq.Expressions;

namespace FMUtility.Core.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName(this Expression expression)
        {
            var lambda = expression as LambdaExpression;
            if (lambda == null)
                throw new ArgumentException("expression");

            var memberExpression = GetMember(lambda);
            return memberExpression.Member.Name;
        }

        private static MemberExpression GetMember(LambdaExpression lambdaExpression)
        {
            MemberExpression memberExpression = null;
            if (lambdaExpression.Body.NodeType == ExpressionType.Convert)
                memberExpression = ((UnaryExpression) lambdaExpression.Body).Operand as MemberExpression;
            else if (lambdaExpression.Body.NodeType == ExpressionType.MemberAccess)
                memberExpression = lambdaExpression.Body as MemberExpression;

            if (memberExpression == null)
                throw new ArgumentException("expression");
            return memberExpression;
        }
    }
}