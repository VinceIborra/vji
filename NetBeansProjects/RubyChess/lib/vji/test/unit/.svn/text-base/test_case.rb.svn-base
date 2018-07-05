$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'vji/assertion_failed_exception'

class Test::Unit::TestCase

  def assert_exception_raised(message, exception_class=AssertionFailedException, &block)
    exception = assert_raise(exception_class, &block)
    assert_equal(message, exception.message)
  end

end
