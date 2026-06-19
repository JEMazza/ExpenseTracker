using System;

namespace ExpenseServices.Requests {
    public class ExpenseSearchRequest:IRequest {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public IEnumerable<int> Types { get; set; }
        public IEnumerable<int> Places { get; set; }
        public string Valid() {
            if (From.HasValue && To.HasValue && (From.Value > To.Value)) {
                return Resources.ErrorMessages.ExpenseSearchDateError;
            }
            return string.Empty;
        }
    }
}
