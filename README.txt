# 3DChess
Creators: Brianna Hill and Karl Honse
Reason for creation: School assignment
Last commit: approx. midnight 3/29/17
Last ReadMe update: 3/29/17

===== Functioning capabilities as of latest commit (approx. midnight 3/29/17) =====
    - board procedurely generates
    - pieces procedurely generated in starting positions from prefabs based on 3D models
        ** with latest commit this is broken, see note on ValidMoves() below
    - multiplayer capabilities added to the entire game
        - including network identities for each component
        - Server is automatically player1 (white pieces), Client is automatically player2 (black pieces)
    - log created
        ** still has example code attached, see source below
    - piece movement restricted to the squares of the board
        - i.e. within the bounds of the board
        - if dropped between two squares (or off edge of board), piece will snap to nearest sqaure
    - camera & lighting modified to change based on whose turn it is
        ** not tested, see below
    - logic created for each of the components listed below, even if not currently functioning

===== Noticeable things missing from latest commit (approx. midnight 3/29/17) =====
  Note that while these components might not function, the base logic for each more or less is included in the latest code
  but has not been completely worked out.
    - cannot take turns
    - players can control all pieces
    - log does not work
        - meaning scoring also does not work
    - multiple pieces can sit on same square at same time
        - meaning captures don't work
    - ValidMoves() function not working
        ** currently suspected as source of problem in piece generation
        - determines if piece was dropped in a valid spot (based on rules of chess)
            - basic rules only, nothing complex (complex equals castling or more difficult)
            
===== Attributions/Sources =====
Instructor: Dmitriy Babichenko

Thanks to classmates Tim and Bill for helping us manipulate the models in Maya so that the materials could be properly
applied in Unity and for helping us condense multiple scripts for the pieces into one!

Black Square texture:
    Dake~commonswiki. Granite azul noce. Digital image. Wikipedia. N.p., 13 Aug. 2005. Web. 23 Jan. 2017.
    <https://commons.wikimedia.org/wiki/File:Granite_azul_noce.jpg>.
White Square texture:
    Dake~commonswiki. Granite softgreen. Digital image. Wikimedia Commons. N.p., 19 Sept. 2005. Web. 23 Jan. 2017.
    <https://commons.wikimedia.org/wiki/File:Granite_softgreen.jpg>.
3D Models for pieces:
    ehtanjurman. wireframe.stl. Digital file. Thingiverse. MakerBot Industries, LLC. 14 March 2013. Web. 23 March 2017.
    <http://www.thingiverse.com/thing:61774>
Textures for pieces:
    Nobiax/Yughues. Yughues Free Concrete Materials. Digital File. Unity Asset Store. Unity Technologies. 19 Nov. 2013. Web.
    25 Jan. 2017. <https://www.assetstore.unity3d.com/en/#!/content/12951>
    Pattern 15 used for Black Pieces, Pattern 19 used for White pieces.
    
Initial idea for Log was a ScrollView but we couldn't figure out how to add text to it, but we found this forum post and
documentation which is where the current code comes from. The base code from the documentation example is what is currently
implemented in our code, it has not yet been changed.
    https://forum.unity3d.com/threads/scrolling-textarea.22358/
    https://docs.unity3d.com/ScriptReference/GUILayout.BeginScrollView.html

Connection testing information came from documentation.
    https://docs.unity3d.com/ScriptReference/Network.TestConnection.html
    
We were reading a bit through this forum on taking turns.
    https://forum.unity3d.com/threads/is-it-easy-to-make-a-turn-based-game.132856/
