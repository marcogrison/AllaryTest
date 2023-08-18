using AllariTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllariTest.Domain.Interfaces
{
    public interface IRickAndMortyApiService
    {
        Task<List<Character>> GetCharactersAsync();
    }
}
