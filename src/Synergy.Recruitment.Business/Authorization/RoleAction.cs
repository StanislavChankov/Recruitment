using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;

namespace Synergy.Recruitment.Business.Authorization
{
    /// <summary>
    /// The role action class.
    /// </summary>
    /// <seealso cref="IAuthorizationRequirement" />
    public sealed class RoleAction : IAuthorizationRequirement
    {
        #region Fields

        private static readonly IDictionary<int, string> _actionsDict = new Dictionary<int, string>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAction" /> class.
        /// </summary>
        public RoleAction(string name, int value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (value <= 0)
            {
                throw new ArgumentException(nameof(value));
            }

            EnsureUniqueness(name, value);

            Name = name;
            Value = value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the actions.
        /// </summary>
        public static IEnumerable<int> ActionValues => _actionsDict.Keys;

        /// <summary>
        /// Gets the action names.
        /// </summary>
        public static IEnumerable<string> ActionNames => _actionsDict.Values;

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public int Value { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        public override string ToString() => _actionsDict[Value];

        private static void EnsureUniqueness(string value, int key)
        {
            if (_actionsDict.TryGetValue(key, out string currentValue))
            {
                throw new InvalidOperationException($"Overlapping RoleActions detected for key: {key}. Tried to replace {currentValue} with {value}");
            }

            _actionsDict.Add(key, value);
        }

        #endregion
    }
}
