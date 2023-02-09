namespace Domain.Aggregates
{
    public class SelectedItem : Item , IAggregateRoot
    {    
        public PrintDetails SpecificPrintDetails { get; private set; }

        /// <summary>
        /// needed by ef core
        /// </summary>
        private SelectedItem() { }

        public SelectedItem(Guid id, PrintDetails specificPrintDetails)
        {
            Id = id;
            SpecificPrintDetails = specificPrintDetails;
        }

        public static SelectedItem Create(TimeSpan time, double filament, double height, bool handPainted)
        {
            var id = Guid.NewGuid();
            var specificPrintDetails = PrintDetails.Create(time, filament, height, handPainted);

            return new SelectedItem(id, specificPrintDetails);
        }
    }
}
