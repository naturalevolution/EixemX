namespace EixemX.Services.Base
{
    public abstract class BaseModel
    {
        protected string DisplayDouble(double value)
        {
            return string.Format("{0:0.##}", value);
        }
    }
}