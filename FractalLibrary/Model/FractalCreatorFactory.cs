/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/07/2014
 * Time: 23:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using FractalLibrary.Model;
using System.IO;
using Logger;

namespace FractalLibrary.Model
{
	/// <summary>
	/// Description of FractalFactory.
	/// </summary>
    public static class FractalCreatorFactory
    {
        private static readonly Dictionary<string, IFractalCreator> _dictionary =
            new Dictionary<string, IFractalCreator>();

        static FractalCreatorFactory()
        {
            try
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                foreach (var fi in Directory.GetFiles(dir, "*.dll"))
                {
                    Assembly a = Assembly.LoadFrom(fi);
                    foreach (Type type in a.GetTypes())
                    {
                        if (type.GetInterface(typeof(IFractalCreator).Name) != null && !type.IsAbstract)
                        {
                            Add((IFractalCreator)Activator.CreateInstance(type));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LoggerProvider.Instance.TraceException(e, "FractalFactory failed!");
            }
        }

        public static IFractalCreator GetFractalCreator(string name)
        {
            if (!_dictionary.ContainsKey(name))
                throw new ArgumentException("!_dictionary.ContainsKey(name)");
            return _dictionary[name];
        }

        public static IEnumerable<string> GetNames()
        {
            return _dictionary.Keys;
        }

        public static IEnumerable<IFractalCreator> GetFractalCreators()
        {
            return _dictionary.Values;
        }

        private static void Add(IFractalCreator fractal)
        {
            if (fractal == null)
                throw new ArgumentNullException("fractal");
            if (_dictionary.ContainsKey(fractal.Name))
                throw new ArgumentException("_dictionary.ContainsKey(fractal.Name)");
            _dictionary.Add(fractal.Name, fractal);
        }
    }
}
