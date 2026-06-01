namespace ExpenseServices.Requests {
    internal interface IRequest {

        /// <summary>
        /// Validates the request
        /// </summary>
        /// <returns>Returns a message if there is an error, empty if it is valid</returns>
        public string Valid();
    }
}
