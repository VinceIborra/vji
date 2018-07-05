require 'vji'
require 'chess/file'
require 'chess/rank'
require 'chess/colour'

module Chess
  module Assertions

    include Vji::Assertions

    private

    def assert_valid_file(file)
      assert_not_nil(file, "<nil> is not a valid file value.")
      if (!File.values.include?(file))
        raise AssertionFailedException, "<#{file.to_s.demodulized}> is not a valid file value."
      end
    end

    def assert_valid_rank(rank)
      assert_not_nil(rank, "<nil> is not a valid rank value.")
      if (!Rank.values.include?(rank))
        raise AssertionFailedException, "<#{rank.to_s.demodulized}> is not a valid rank value."
      end
    end

    def assert_valid_piece_type(expected_type, piece_type)
      if (piece_type != expected_type)
        raise AssertionFailedException, "<#{expected_type.to_s.demodulized}> expected but was <#{piece_type.to_s.demodulized}>."
      end
    end

    def assert_valid_shade(shade)
      assert_not_nil(shade, "<nil> is not a valid shade value.")
      if (!Shade.values.include?(shade))
        raise AssertionFailedException, "<#{shade.to_s.demodulized}> is not a valid shade value."
      end
    end

    def assert_valid_colour(colour)
      assert_not_nil(colour, "<nil> is not a valid colour value.")
      if (!Colour.values.include?(colour))
        raise AssertionFailedException, "<#{colour.to_s.demodulized}> is not a valid colour value."
      end
    end

  end
end