class ClassDiagram
  constructor: (x, y, data) ->
    @base_x = x
    @base_y = y
    @class_name = data.className
    @methods = data.methods

  get_Layer: =>
    @classGroup = new Kinetic.Group({draggable: true})
    classLayer = new Kinetic.Layer();
    @classGroup.draggable(true)
    box = @_create_box()
    line = @_drawLine()
    liness = @_drawLines()
    @classGroup.add(box);
    @classGroup.add(line);
    @classGroup.add(liness);
    @_render_methods()
    publicMethod = @_publicMethod()
    @classGroup.add(publicMethod)

    class_names = @_get_className()
    @classGroup.add(class_names)
	
    
    classLayer.add(@classGroup)
    classLayer

  _render_methods:() =>
    current_y = @base_y
    for method in @methods
      complexText = new Kinetic.Text({
          x: @base_x-17,
          y: current_y,
          text: method.methodName,
          fontSize: 11,
          fontFamily: "Verdana",
          textStroke: "#333",
          textFill: "#333",
          textStrokeWidth: 0.1,
          align: "center",
          verticalAlign: "middle"});
      @classGroup.add(complexText)
      current_y = current_y + 20

  _drawLines: =>
     points = [
        x: @base_x - 57
        y: @base_y + 70
     ,
        x: @base_x+143
        y: @base_y + 70
     ]
     line = new Kinetic.Line({
                points: points
                stroke: "black"
                strokeWidth: 1
                lineCap: "round"
                lineJoin: "round"
           });

  _get_className: =>
    complexText = new Kinetic.Text({
          x: @base_x+3,
          y: @base_y-40,
          text: @class_name,
          fontSize: 13,
          fontFamily: "Verdana",
          textStroke: "#333",
          textFill: "#333",
          textStrokeWidth: 0.1,
          padding: 10,
          align: "center",
          verticalAlign: "middle"});

  _publicMethod:() =>
    ComplexText = new Kinetic.Text({
         x: @base_x+2,
         y: @base_y-15,
         text: "Public Methods",
         fontSize: 11,
         fontFamily: "Verdana",
         textStroke: "#333",
         textFill: "#333",
         textStrokeWidth: 0.1,
         align: "center",
         verticalAlign: "middle"});
      

  _create_box: =>     
    rectX = @base_x - 57;
    rectY = @base_y - 55;
    box = new Kinetic.Rect({
                x: rectX,
                y: rectY,
                width: 200,
                height: 200,
                cornerRadius: 5,
                fill: "#ffffff",
                stroke: "black",
                strokeWidth: 1
            });
   _drawLine: =>
     points = [
        x: @base_x - 57
        y: @base_y-25
     ,
        x: @base_x + 143
        y: @base_y-25
     ]
     line = new Kinetic.Line({
                points: points
                stroke: "black"
                strokeWidth: 1
                lineCap: "round"
                lineJoin: "round"
            });



		



exports = this
exports.ClassDiagram = ClassDiagram