using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllariTest.Models
{
    public class Character
    {
        public Character() {}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
    }

    public class CharacterResponse
    {
        public List<Character> Results { get; set; }
    }

}