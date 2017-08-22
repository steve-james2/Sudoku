using System;
using System.Collections.Generic;

namespace Sudoku.Library
{
	public static class Assumes
	{
		public static void NotNull<T>( T value, string paramName ) where T : class
		{
			if( (object)value == null )
				throw new ArgumentNullException( paramName );
		}

		public static void NotNull<T>( T value, string paramName, string message ) where T : class
		{
			if( (object)value == null )
				throw new ArgumentNullException( paramName, message );
		}

		public static void NotNullOrEmpty( string value, string paramName )
		{
			if( string.IsNullOrEmpty( value ) )
				throw new ArgumentException( paramName );
		}

		public static void NotNullOrZeroLength<T>( T[] array, string paramName )
		{
			if( (object)array == null || array.Length == 0 )
				throw new ArgumentException( paramName );
		}

		public static void NotNullOrZeroLength<T>( IList<T> list, string paramName )
		{
			if( (object)list == null || list.Count == 0 )
				throw new ArgumentException( paramName );
		}
	}
}