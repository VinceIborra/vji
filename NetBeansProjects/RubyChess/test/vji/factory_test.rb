require 'vji'

class Vji::FactoryTest < Test::Unit::TestCase

    attr_reader :factory

    def setup
      @factory = Factory.new
    end
    
    def test_new_assertion_failed_exception
      exception = factory.new_assertion_failed_exception("some message")
      assert_not_nil(exception)
      assert_kind_of(AssertionFailedException, exception)
      assert_equal("some message", exception.message)
    end
end
