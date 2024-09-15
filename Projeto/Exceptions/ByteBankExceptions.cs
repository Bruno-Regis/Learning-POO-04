namespace Projeto.Exceptions
{

	[Serializable]
	public class ByteBankException : Exception
	{
		public ByteBankException() { }
		public ByteBankException(string message) : base("Ocorreu a seguinte Exceção: " + message) { }
		public ByteBankException(string message, Exception inner) : base(message, inner) { }
		protected ByteBankException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
