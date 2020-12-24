namespace WebPlataformBlazor.Src.Code.Models
{
    public abstract class BaseModel
    {
        public virtual long Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }

        public override string ToString()
        {
            return Name + " - " + Description;
        }
    }
}
