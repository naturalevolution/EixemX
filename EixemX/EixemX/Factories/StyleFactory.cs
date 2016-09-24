using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StyleFactory))]
namespace EixemX.Factories
{
    public class StyleFactory : IStyleFactory
    {
        public Style EntryDefault()
        {
            throw new NotImplementedException();
        }
    }

    public interface IStyleFactory
    { 
        Style EntryDefault();
    }
}
