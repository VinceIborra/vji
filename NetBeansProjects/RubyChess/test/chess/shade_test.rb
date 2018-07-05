$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'

module Chess
  class ShadeTest < Test::Unit::TestCase

    def test_values
      assert_equal(
        [
          Shade::Light,
          Shade::Dark
        ],
        Shade.values
      )
    end
  end
end
