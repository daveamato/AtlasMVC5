using Atlas.Components.Mvc;
using Atlas.Resources.Form;
using Atlas.Tests.Objects;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Xunit;

namespace Atlas.Tests.Unit.Components.Mvc
{
    public class RequiredAdapterTests
    {
        #region RequiredAdapter(ModelMetadata metadata, ControllerContext context, RequiredAttribute attribute)

        [Fact]
        public void RequiredAdapter_SetsErrorMessage()
        {
            ModelMetadata metadata = new DataAnnotationsModelMetadataProvider()
                .GetMetadataForProperty(null, typeof(AdaptersModel), "Required");
            RequiredAttribute attribute = new RequiredAttribute();

            new RequiredAdapter(metadata, new ControllerContext(), attribute);

            String expected = Validations.Required;
            String actual = attribute.ErrorMessage;

            Assert.Equal(expected, actual);
        }

        #endregion
    }
}
