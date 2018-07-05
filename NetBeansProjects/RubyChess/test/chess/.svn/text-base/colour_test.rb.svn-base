$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'

module Chess
  class ColourTest < Test::Unit::TestCase

    def test_values
      assert_equal(
        [
          Colour::Black,
          Colour::White
        ],
        Colour.values
      )
    end
  end
end
