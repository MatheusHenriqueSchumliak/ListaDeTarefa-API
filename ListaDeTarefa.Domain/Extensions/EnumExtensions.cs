using System.ComponentModel;

namespace ListaDeTarefa.Domain.Extensions
{
	public static class EnumExtensions
	{
		public static string ObterDescricao(this Enum value)
		{
			var field = value.GetType().GetField(value.ToString());
			var attr = (DescriptionAttribute?)Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute));
			return attr?.Description ?? value.ToString();
		}
	}
}
