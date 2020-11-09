using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BlazorOverview.Models
{
    public class MyNote : ICloneable
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        [Required(ErrorMessage = "事項標題不可為空白")]
        public string Title { get; set; }

        public MyNote Clone()
        {
            return ((ICloneable)this).Clone() as MyNote;
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }
    }
}
