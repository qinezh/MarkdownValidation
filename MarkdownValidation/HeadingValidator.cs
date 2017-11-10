using System.Collections.Generic;

using Markdig.Syntax;
using MarkdigEngine.Extensions;
using Microsoft.DocAsCode.Common;

namespace MarkdownValidation
{
    public static class HeadingValidator
    {
        public static IMarkdownObjectValidator ExpectOnlyOneH1()
        {
            var context = new Dictionary<string, object>();

            return MarkdownObjectValidatorFactory.FromLambda<HeadingBlock>(
                block =>
                {
                    if (block.Level == 1)
                    {
                        if (context.TryGetValue("count", out object countObj) && countObj is int count)
                        {
                            context["count"] = count + 1;
                        }
                    }
                },
                tree =>
                {
                    context.Add("count", 0);
                },
                tree =>
                {
                    if (context.TryGetValue("count", out object countObj) && countObj is int count)
                    {
                        if (count != 1)
                        {
                            Logger.LogError("Expected one title in one document.");
                        }
                    }
                }
            );
        }
    }
}
