package vji.chess.mvc;
import vji.mvc.*;
import vji.chess.*;

/**
 *
 * @author vji
 */
public class StartBoardViewImpl extends BoardViewImpl implements View {

    public String renderIntro() {
        return
        "\n" +
        "Commands:\n" +
        "\n" +
        "  Move A Piece:\n" +
        "    <piece><from_file><from_rank>[<capture>]<to_file><to_rank>\n" +
        "\n" +
        "    piece   - p,r,n,b,q,k\n" +
        "    file    - a,b,c,d,e,f,g,h\n" +
        "    rank    - 1,2,3,4,5,6,7,8\n" +
        "    capture - x\n" +
        "\n" +
        "  Other:\n" +
        "    exit - to exit\n" +
        "\n";
    }

    @Override
    public String render(Object model) {
        if (model instanceof Board) {
            return renderIntro() + renderBoard((Board) model) + renderPrompt();
        }
        return "";
    }

}
