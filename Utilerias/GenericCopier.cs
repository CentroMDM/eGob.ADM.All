using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utilerias
{
    public static class GenericCopier<T>
    {
		public static T DeepCopy(object objectToCopy)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				var binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, objectToCopy);
				memoryStream.Seek(0, SeekOrigin.Begin);
				return (T)binaryFormatter.Deserialize(memoryStream);
			}
		}
	}
}
