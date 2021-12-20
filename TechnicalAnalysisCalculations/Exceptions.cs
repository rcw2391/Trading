namespace TechnicalAnalysisCalculations
{
    public class HistoryIntervalMismatchException : Exception
    {
        public HistoryIntervalMismatchException() { }
        public HistoryIntervalMismatchException(string message) :base(message) { }
        public HistoryIntervalMismatchException(string message, Exception inner) : base(message, inner) { }
    }


    [Serializable]
    public class InvalidPeriodException : Exception
    {
        public InvalidPeriodException() { }
        public InvalidPeriodException(string message) : base(message) { }
        public InvalidPeriodException(string message, Exception inner) : base(message, inner) { }
        protected InvalidPeriodException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class EmptyHistoryException : Exception
    {
        public EmptyHistoryException() { }
        public EmptyHistoryException(string message) : base(message) { }
        public EmptyHistoryException(string message, Exception inner) : base(message, inner) { }
        protected EmptyHistoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InsufficentHistoryException : Exception
    {
        public InsufficentHistoryException() { }
        public InsufficentHistoryException(string message) : base(message) { }
        public InsufficentHistoryException(string message, Exception inner) : base(message, inner) { }
        protected InsufficentHistoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidStartException : Exception
    {
        public InvalidStartException() { }
        public InvalidStartException(string message) : base(message) { }
        public InvalidStartException(string message, Exception inner) : base(message, inner) { }
        protected InvalidStartException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InvalidHistoryException : Exception
    {
        public InvalidHistoryException() { }
        public InvalidHistoryException(string message) : base(message) { }
        public InvalidHistoryException(string message, Exception inner) : base(message, inner) { }
        protected InvalidHistoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class InconsistentStockIdException : Exception
    {
        public InconsistentStockIdException() { }
        public InconsistentStockIdException(string message) : base(message) { }
        public InconsistentStockIdException(string message, Exception inner) : base(message, inner) { }
        protected InconsistentStockIdException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
