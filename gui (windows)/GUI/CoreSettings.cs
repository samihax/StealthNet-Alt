//StealthNet
//Copyright (C) 2009 Lars Regensburger, Roland Moch, T.Norad

//This program is free software; you can redistribute it and/or
//modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2
//of the License, or (at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program; if not, write to the Free Software
//Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;

namespace Regensburger.RShare
{
    public sealed class CoreSettings
        : ICoreSettings
    {
        public string this[string propertyName]
        {
            get
            {
                if (propertyName == null)
                    throw new ArgumentNullException("propertyName");

                return Properties.Settings.Default[propertyName].ToString();
            }
            set
            {
                if (propertyName == null)
                    throw new ArgumentNullException("propertyName");
                if (value == null)
                    throw new ArgumentNullException("value");

                Properties.Settings.Default[propertyName] = value;
            }
        }

        public void Save()
        {
            Properties.Settings.Default.Save();
        }

        public void Upgrade()
        {
            Properties.Settings.Default.Upgrade();
        }
    }
}