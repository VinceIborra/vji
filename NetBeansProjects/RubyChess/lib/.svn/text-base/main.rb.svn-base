require "factory"

factory = Factory.new
board = factory.new_board()
parser = factory.new_parser()
controller = factory.new_controller(board)
renderer = factory.new_renderer()
driver = factory.new_driver(board, parser, controller, renderer)
driver.run