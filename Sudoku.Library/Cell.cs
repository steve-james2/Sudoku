using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Library
{
    public class Cell
    {
        public Cell( IEnumerable<CellValue> possibleValues )
        {
            Assumes.NotNull(possibleValues, nameof(possibleValues));
            Assumes.NotNullOrZeroLength( possibleValues.ToArray(), nameof(possibleValues) );

            _possibleValues = possibleValues.Distinct().ToList();
        }

        public CellValue Value => _possibleValues.Count() == 1 ? _possibleValues.Single() : null;

        public void MustBe( CellValue value )
        {
            Assumes.NotNull( value, nameof( value ) );

            var cellValue = Value;
            if ( cellValue != null && cellValue != value )
                throw new InconsistentDataException(
                    $"Attempt to set {nameof( Value )} to {value.Name} when it is already set to {Value.Name}." );

            if ( _possibleValues.All( pv => pv != value ) )
                throw new InconsistentDataException(
                    $"Attempt to set {nameof( Value )} to {value.Name} when this value is not in the list of possible values for this cell." );

            _possibleValues.RemoveAll( pv => pv != value );
        }

        private List<CellValue> _possibleValues;

        public IReadOnlyList<CellValue> PossibleValues => _possibleValues;

        public void CannotBe( IEnumerable<CellValue> values )
        {
            Assumes.NotNull( values, nameof( values ) );

            if ( !_possibleValues.Except( values ).Any() )
                throw new InconsistentDataException(
                    $"Attempt to remove values from the set of possible values would result in there being no possible values for the cell." );

            _possibleValues.RemoveAll( pv => values.Any( v => v == pv ) );
        }

    }
}
