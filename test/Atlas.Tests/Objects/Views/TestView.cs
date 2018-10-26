using Atlas.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atlas.Tests.Objects
{
    public class TestView : BaseView
    {
        [StringLength(128)]
        public String Title { get; set; }
    }
}
