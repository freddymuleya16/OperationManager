namespace OperationManager.Models
{
    public class Operation
    {
        public int OperationID { get; set; }
        public string Name { get; set; }
        public int OrderInWhichToPerform { get; set; }
        public byte[] ImageData { get; set; }
        public Device Device { get; set; }
    }
}
