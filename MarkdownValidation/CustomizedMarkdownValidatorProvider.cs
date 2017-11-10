using System.Composition;
using System.Collections.Immutable;

using MarkdigEngine.Extensions;

namespace MarkdownValidation
{
    [Export("markdig_validation_testing", typeof(IMarkdownObjectValidatorProvider))]
    public class CustomizedMarkdownValidatorProvider : IMarkdownObjectValidatorProvider
    {
        public ImmutableArray<IMarkdownObjectValidator> GetValidators()
        {
            return ImmutableArray.Create(HeadingValidator.ExpectOnlyOneH1());
        }
    }
}
