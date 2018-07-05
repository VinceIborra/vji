$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'chess'

module Chess
  class FileTest < Test::Unit::TestCase

    def test_values
      assert_equal(
        [
          File::File_a,
          File::File_b,
          File::File_c,
          File::File_d,
          File::File_e,
          File::File_f,
          File::File_g,
          File::File_h
        ],
        File.values
      )
    end

  end
end
