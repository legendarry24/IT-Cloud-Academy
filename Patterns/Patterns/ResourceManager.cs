using System;

namespace Patterns
{
	class ResourceManager : IDisposable
	{
		private bool disposed = false;

		private string Name { get; }

		public ResourceManager(string name)
		{
			this.Name = name;
		}

		public void Dispose()
		{
			Console.WriteLine(this.Name);

			// true means that the Dispose method is called from the managed code and should clean up both managed and unmanaged resources
			this.Dispose(true);
			// prevent the Finalizer's invocation (remove pointer to this object from finalization queue)
			// this will prevent the finalizer from releasing unmanaged resources that have already been freed
			GC.SuppressFinalize(this);
		}

		// derived classes can override this method to implement their own clean up logic
		protected virtual void Dispose(bool disposing)
		{
			if (this.disposed)
			{
				return;
			}

			if (disposing)
			{
				// clean any managed resources
				// for example, call Dispose on instances of managed wrappers of unmanaged resources (e.g. SqlConnection class)
				Console.WriteLine("Free managed resources");
				Console.WriteLine(this.Name);
			}

			// clean unmanaged resources
			Console.WriteLine("Free unmanaged resources");
			Console.WriteLine(this.Name);

			// set flag to true to avoid errors while disposing the resources that have already been disposed
			this.disposed = true;
		}

		// overriding of the Finalizer is required only in case when the class operates unmanaged resources directly
		~ResourceManager()
		{
			Console.WriteLine("Finalizer");
			Console.WriteLine(this.Name);

			// false means that the Dispose method is called from the unmanaged code and should not clean up managed resources.
			// in this way only unmanaged resources will be disposed during finalization. Because you can get an error if you try to 
			// dispose managed resources from finalizer as they could have already been collected by GC
			this.Dispose(false);
		}
	}
}
