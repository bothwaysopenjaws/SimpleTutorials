using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace SimpleTutorials.Wpf.Authentication.Converters
{
    /// <summary>
    /// Transforme un booléen en une visibilité :  Si true => Visible, si False => Collapsed
    /// le Paramètre '!' inverse le résultat : Si true => Collapsed, si False => Visible
    /// </summary>
    class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converti le booléen en visibilité
        /// </summary>
        /// <param name="value">Valeur (booleen)</param>
        /// <param name="targetType">Type visé</param>
        /// <param name="parameter">paramètre</param>
        /// <param name="culture">Culture</param>
        /// <returns>Visibilité retournée</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibility = Visibility.Collapsed;



            if (
                ((value is true && (parameter as string) != "!")) 
                || 
                ((value is false && (parameter as string) == "!"))
                )
                visibility = Visibility.Visible;
            ;
            return visibility;
        }

        /// <summary>
        /// Convertie une visibilité en booléen. Non utilisé donc non implémenté
        /// </summary>
        /// <param name="value">Valeur (booleen)</param>
        /// <param name="targetType">Type visé</param>
        /// <param name="parameter">paramètre</param>
        /// <param name="culture">Culture</param>
        /// <returns>Visibilité retournée</returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
