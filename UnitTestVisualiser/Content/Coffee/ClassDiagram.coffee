class ClassDiagram
  constructor: (x, y, data) ->
    @base_x = x
    @base_y = y
    @class_name = data.ClassName
    @methods = data.PublicMethods
    @current_y = @base_y

  get_Layer: =>
    console.log 'in get_Layer'
    @classGroup = new Kinetic.Group({draggable: true})
    @classBody = new Kinetic.Group()

    classLayer = new Kinetic.Layer();
    
    @classGroup.draggable(true)
    @_render_methods()
    console.log 'about to get props'
    props = @_publicProperties()
    box = @_create_box()
   
    line = @_drawLine()
    publicMethod = @_publicMethod()
    


    # add to parent group
    @classGroup.add(box);
    @classGroup.add(line);
    
    @classGroup.add(publicMethod)
    @classGroup.add(props)
    @classGroup.add(@classBody); 

    class_names = @_get_className()
    @classGroup.add(class_names)
	

    # register click event
    @classGroup.on('mouseup', -> box.transitionTo({strokeWidth: 4, duration: 0.3, easing: 'ease-in-out'}))
    
    classLayer.add(@classGroup)
    classLayer

  _render_methods:() =>
    
    for method in @methods
      complexText = new Kinetic.Text({
          x: @base_x-17,
          y: @current_y,
          text: method,
          fontSize: 9,
          fontFamily: "Verdana",
          textStroke: "#333",
          textFill: "#333",
          textStrokeWidth: 0.1,
          align: "center",
          verticalAlign: "middle"});
      @classBody.add(complexText)
      @current_y = @current_y + 20

  _publicProperties:() =>
    ComplexText = new Kinetic.Text({
         x: @base_x-15,
         y: @current_y,
         text: "Properties",
         fontSize: 10,
         fontStyle: "bold",
         fontFamily: "Verdana",
         textStroke: "#333",
         textFill: "#333",
         textStrokeWidth: 0.1,
         align: "center",
         verticalAlign: "middle"});


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
         fontSize: 10,
         fontStyle: "bold",
         fontFamily: "Verdana",
         textStroke: "#333",
         textFill: "#333",
         textStrokeWidth: 0.1,
         align: "center",
         verticalAlign: "middle"});
      

  _create_box: =>     
    console.log("base_y: #{@base_y}")
    console.log("current_y: #{@current_y}")
    rectX = @base_x - 57;
    rectY = @base_y - 55;
    box = new Kinetic.Rect({
                x: rectX,
                y: rectY,
                width: 200,
                height: 68  + (@current_y - @base_y),
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