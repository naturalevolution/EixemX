using System;
using EixemX.Constants;
using EixemX.Controls.Buttons;
using EixemX.Factories;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(EventFactory))]
namespace EixemX.Factories
{
    public interface IEventFactory
    { 
    }

    public class EventFactory : IEventFactory
    {
        public void ButtonOnPressed(Button element, ButtonStyle buttonStyle)
        {
            
        }
    }
}