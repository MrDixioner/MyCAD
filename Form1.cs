using MyCAD.Entities;
using MyCAD.Methods;
using MyCAD.EntryForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyCAD {
	public partial class GraphicsForm : Form {
		public GraphicsForm() {
			InitializeComponent();
		}

		#region " Variables "		
		private List<EntityObject> entities = new List<EntityObject>();
		private List<Ellipse> tempEllipse=new List<Ellipse>();
		private LwPolyline tempPolyline = new LwPolyline();
		// All vectors
		private Vector3 currentPosition;
		private Vector3 p1;
		private Vector3 p2;
		private Vector3 p3;
		private Vector3 p4;
		private Vector3 panPoint;
		// System point
		private System.Drawing.Point firstCorner;
		private System.Drawing.Point startLocation;
		// int
		private int DrawIndex = -1;
		private int ModifyIndex = -1;
		private int EntityIndex = -1;
		private int AnnotateIndex = -1;
		private int ClickNum = 1;
		private int ClickZoom = 1;
		private int cursorIndex = 0;
		public int direction;
		private int sidesQty = 5;
		private int inscribed = 0; // Внешний или внутренний диаметр полигона
		// float
		private float XScroll;
		private float YScroll;
		private float ScaleFactor = 1.0f;
		private float cursorSize = 0;
		private float x1, x2, y1, y2;
		private float edit_cursorSize = 2.5f;
		private float draw_cursorSize = 15.0f;
		// bool
		private bool activeDrawing = false;
		private bool activeZoom = false;
		private bool activePan = false;
		private bool activeModify = false;
		private bool activeSelection = true;
		private bool selectWindow = false;
		// Base size of Drawing
		private SizeF drawingSize = new SizeF(297, 210);
		public string Value1 = "0", Value2 = "0", Value3 = "0", Value4 = "0";
		public bool Value5;

		public Text tempText;
		#endregion

		#region " PictureBox events "
		#region Mouse down
		private void drawing_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				if (!activePan)
					startLocation = e.Location;
				activePan = true;
				panPoint = currentPosition;
				drawing.Cursor = Cursors.Hand;
				if (activeDrawing || activeZoom) {
					cursorIndex = 1;
					cursorSize = 15;
				} else {
					cursorIndex = 0;
					cursorSize = 0;
				}
			}

			if (e.Button == MouseButtons.Left) {
				if (activeZoom) {
					switch (ClickZoom) {
						case 1:
							firstCorner = e.Location;
							ClickZoom++;
							break;
						case 2:
							SetZoomWin(firstCorner, e.Location);
							ActiveCursor(cursorIndex, cursorSize);
							activeZoom = false;
							ClickZoom = 1;
							break;
					}
				} else if (!activeDrawing && activeSelection) {
					if (EntityIndex == -1)
						selectWindow = true;
					else
						entities[EntityIndex].Select();

					if (selectWindow) {
						if (activeModify)
							ActiveCursor(1, draw_cursorSize);

						switch (ClickNum) {
							case 1:
								p1 = currentPosition;
								ClickNum++;
								break;
							case 2:
								Method.SelectWindow(entities, p1, currentPosition);
								if (activeModify)
									ActiveCursor(2, edit_cursorSize);
								selectWindow = false;
								ClickNum = 1;
								break;
						}
					}
				} else {
					if (activeDrawing) {
						switch (DrawIndex) {
							case 10: // Arc - 3-Point
							case 11: // Arc - Start, Center, End
							case 12: // Arc - Start, Center, Angle
							case 13: // Arc - Start, Center, Length
							case 14: // Arc - Start, End, Angle
							case 15: // Arc - Start, End, Direction
							case 16: // Arc - Start, End, Radius
							case 17: // Arc - Center, Start, End
							case 18: // Arc - Center, Start, Angle
							case 19: // Arc - Center, Start, Length
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										break;
									case 2:
										p2 = currentPosition;
										ClickNum++;
										break;
									case 3:
										Method.GetArc(DrawIndex, p1, p2, currentPosition, out Arc resultArc);
										entities.Add(resultArc);
										CancelAll();
										break;
								}
								break;
							case 21: // Circle - Center, Radius
							case 22: // Circle - Center, Diameter
							case 23: // Circle - 3-Points
							case 24: // Circle - 2-Points
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										break;
									case 2:
										switch (DrawIndex) {
											case 21:
												double r = p1.DistanceFrom(currentPosition);
												entities.Add(new Circle(p1, r));
												CancelAll();
												break;
											case 22:
												r = p1.DistanceFrom(currentPosition) / 2;
												entities.Add(new Circle(p1, r));
												CancelAll();
												break;
											case 23:
												p2 = currentPosition;
												ClickNum++;
												break;
											case 24:
												entities.Add(Method.GetCircleWith2Point(p1, currentPosition));
												CancelAll();
												break;
										}
										break;
									case 3:
										entities.Add(Method.GetCircleWith3Point(p1, p2, currentPosition));
										CancelAll();
										break;
								}
								break;
							case 31: // Ellipse
							case 32: // Elliptical Arc
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										break;
									case 2:
										p2 = currentPosition;
										ClickNum++;
										break;
									case 3:
										switch (DrawIndex) {
											case 31:
												Ellipse ellipse = Method.GetEllipse(p1, p2, currentPosition);
												entities.Add(ellipse);
												CancelAll();
												break;
											case 32:
												p3 = currentPosition;
												tempEllipse.Add(Method.GetEllipse(p1, p2, p3));
												ClickNum++;
												break;
										}
										break;
									case 4:
										p4 = currentPosition;
										ClickNum++;
										break;
									case 5:
										entities.Add(Method.GetEllipticalArc(p1, p2, p3, p4, currentPosition));
										CancelAll();
										break;
								}
								break;
							case 3: // Line
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										break;
									case 2:
										entities.Add(new Line(p1, currentPosition));
										p1 = currentPosition;
										break;
								}
								break;
							case 4: // LwPolyline
								p1 = currentPosition;
								tempPolyline.Vertexes.Add(new LwPolylineVertex(p1.ToVector2));
								ClickNum = 2;
								break;
							case 5: // Polygon
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										using (var setpolygon = new EntryForms.SetPolygonValuesForm()) {
											var result = setpolygon.ShowDialog();
											if (result == DialogResult.OK) {
												sidesQty = setpolygon.SidesQty;
												inscribed = setpolygon.Inscribed;
											} else
												CancelAll();
										}
										break;
									case 2:
										entities.Add(Method.GetPolygon(p1, currentPosition, sidesQty, inscribed));
										CancelAll();
										break;
								}
								break;
							case 6: // Point
								entities.Add(new Entities.Point(currentPosition));
								break;
							case 7: // Rectangle
								switch (ClickNum) {
									case 1:
										p1 = currentPosition;
										ClickNum++;
										break;
									case 2:
										entities.Add(Method.PointToRect(p1, currentPosition, out direction));
										CancelAll();
										break;
								}
								break;
						}

						switch (AnnotateIndex) {
							case 0: // Single text
								entities.Add(new Entities.Point(currentPosition));
								using (var texteditor = new TextEditor(this)) {
									timer1.Enabled = true;
									texteditor.Position = currentPosition;
									var result = texteditor.ShowDialog();

									if (result == DialogResult.OK) {
										entities.Add(tempText);
									}
									CancelAll();
								}
								break;
						}
					}				
					if (activeModify) {
						if (!activeSelection) {
							switch (ClickNum) {
								case 1:
									p1 = currentPosition;
									ClickNum++;
									break;
								case 2:
									switch (ModifyIndex) {
										case 0: // Copy object
											Method.Modify1Selection(ModifyIndex, entities, p1, currentPosition);
											break;
										case 1: // Move object
										case 2: // Rotate object
										case 4: // Scale
											Method.Modify1Selection(ModifyIndex, entities, p1, currentPosition);
											CancelAll();
											break;									
										case 3: // Mirror object
											if (MessageBox.Show("Удалить исходный объект?", "Mirror",
												MessageBoxButtons.YesNo,
												MessageBoxIcon.Question) == DialogResult.Yes) { 
												Method.Modify1Selection(ModifyIndex, entities, p1, currentPosition,true);
											} else {
												Method.Modify1Selection(ModifyIndex, entities, p1, currentPosition, false);
											}
											CancelAll();
											break;
										case 7: // Circular array
											p1 = currentPosition;
											using (var inputarray=new InputCircularArray(this)) {
												timer1.Enabled = true;
												var result = inputarray.ShowDialog();
												if (result == DialogResult.OK) {
													Method.CircularArray2D(entities, p1,
														double.Parse(Value2),
														int.Parse(Value1),
														Value5);
													CancelAll();
												} else
													CancelAll();
											}
											break;
									}
									break;
							}
						}					
					}
				}
				drawing.Refresh();
			}
		}
		#endregion

		#region Paint
		Line extline = new Line();
		private void drawing_Paint(object sender, PaintEventArgs e) {
			e.Graphics.SetParameters(XScroll,YScroll,ScaleFactor, PixelToMillimeters(drawing.Height));
			Pen pen = new Pen(Color.Blue, 0.5f/ScaleFactor);
			Pen extpen = new Pen(Color.Gray, 0.5f/ScaleFactor);
			extpen.DashPattern = new float[] { 1.0f / ScaleFactor, 2.0f / ScaleFactor };

			// TESTS
			foreach (EntityObject entity in entities) {
				switch (entity.Type) {
					case EntityType.Line:
						Vector3 p;
						foreach (EntityObject entity1 in entities) {
							switch (entity1.Type) {
								case EntityType.Ellipse:
									List<Vector3> intersection = Method.LineEllipseIntersection(entity as Line, entity1 as Ellipse);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red,1.0f/ScaleFactor), new Entities.Point(v));
									break;
								case EntityType.Circle:
									intersection = Method.LineCircleIntersection(entity as Line, entity1 as Circle);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 1.0f / ScaleFactor), new Entities.Point(v));
									break;
								case EntityType.Arc:
									intersection = Method.LineArcIntersection(entity as Line, entity1 as Arc);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 1.0f / ScaleFactor), new Entities.Point(v));
									break;
								case EntityType.LwPolyline:
									intersection = Method.LinePolylineIntersection(entity as Line, entity1 as LwPolyline);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 1.0f / ScaleFactor), new Entities.Point(v));
									break;
							}
						}
						break;
					case EntityType.Ellipse:
						foreach (EntityObject entity1 in entities) {
							switch (entity1.Type) {
								case EntityType.LwPolyline:
									List<Vector3> intersection = Method.PolylineEllipseIntersection(entity1 as LwPolyline, entity as Ellipse);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
							}
						}
						break;
					case EntityType.Circle:
						foreach (EntityObject entity1 in entities) {
							switch (entity1.Type) {
								case EntityType.Circle:
									List<Vector3> intersection = Method.CircleCircleIntersection(entity as Circle, entity1 as Circle);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
								case EntityType.Arc:
									intersection = Method.ArcCircleIntersection(entity1 as Arc, entity as Circle);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
								case EntityType.Ellipse:
									intersection = Method.CircleEllipseIntersection(entity as Circle, entity1 as Ellipse);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
								case EntityType.LwPolyline:
									intersection = Method.CirclePolylineIntersection(entity as Circle, entity1 as LwPolyline);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
							}
						}
						break;
					case EntityType.Arc:
						foreach (EntityObject entity1 in entities) {
							switch (entity1.Type) {
								case EntityType.Arc:
									List<Vector3> intersection = Method.ArcArcIntersection(entity as Arc, entity1 as Arc);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
								case EntityType.LwPolyline:
									intersection = Method.ArcPolylineIntersection(entity as Arc, entity1 as LwPolyline);
									foreach (Vector3 v in intersection)
										e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
									break;
							}
						}
						break;
					case EntityType.LwPolyline:
						foreach (EntityObject entity1 in entities) {
							if (entity as LwPolyline!=entity1)
								switch (entity1.Type) {
									case EntityType.LwPolyline:
										List<Vector3> intersection = Method.PolylinePolylineIntersection(entity as LwPolyline, entity1 as LwPolyline);
										foreach (Vector3 v in intersection)
											e.Graphics.DrawPoint(new Pen(Color.Red, 0.5f), new Entities.Point(v));
										break;
								}
						}
						break;
				}
			}

			#region Drawing
			// Draw all entities
			if (entities.Count > 0) {
				foreach (EntityObject entities in entities) {
					e.Graphics.DrawEntity(pen, entities);
				}

				if (EntityIndex != -1) {
					e.Graphics.DrawEntity(new Pen(Color.FromArgb(128, Color.LightBlue), 1.5f / ScaleFactor), entities[EntityIndex]);
					e.Graphics.DrawEntity(new Pen(Color.Blue, 1.0f / ScaleFactor), entities[EntityIndex]);
				}
			}            
			
			// Draw tempPolyline
			if (tempPolyline.Vertexes.Count > 1)
				e.Graphics.DrawLwPolyline(pen, tempPolyline);

			#endregion

			#region Extended
			// Draw line extended
			extline = new Line(p1, currentPosition);

			// Draw tempEllipse
			if (tempEllipse.Count > 0) {
				foreach (Ellipse elp in tempEllipse)
					e.Graphics.DrawEllipse(extpen, elp);
			}

			switch (DrawIndex) {
				case 3: // Line
				case 4: // LwPolyline
					if (ClickNum == 2) {
						e.Graphics.DrawLine(extpen, extline);
					}
					break;
				case 5: // Polygon
					if (ClickNum == 2) {
						e.Graphics.DrawLine(extpen, extline);
						LwPolyline lw = Method.GetPolygon(p1, currentPosition, sidesQty, inscribed);
						e.Graphics.DrawLwPolyline(extpen, lw);
					}
					break;
				case 7: // Rectangle
					if (ClickNum == 2) {
						LwPolyline lw = Method.PointToRect(p1, currentPosition, out direction);
						e.Graphics.DrawLwPolyline(extpen, lw);
					}
					break;
				case 10: // Arc 3-Points
					switch (ClickNum) {
						case 2:
							e.Graphics.DrawLine(extpen, extline);
							break;
						case 3:
							Method.GetArc(DrawIndex, p1, p2, currentPosition, out Arc drawArc);
							e.Graphics.DrawArc(extpen, drawArc);
							break;
					}
					break;
				case 13: // Arc - Start, Center, Length
				case 14: // Arc - Start, End, Angle					
				case 15: // Arc - Start, End, Direction					
				case 17: // Arc - Center, Start, End					
				case 18: // Arc - Center, Start, Angle					
					switch (ClickNum) {
						case 2:							
							e.Graphics.DrawLine(extpen, extline);
							break;
						case 3:
							e.Graphics.DrawLine(extpen, extline);
							Method.GetArc(DrawIndex, p1, p2, currentPosition, out Arc drawArc);
							e.Graphics.DrawArc(extpen, drawArc);
							break;
					}
					break;
				case 11: // Arc - Start, Center, End
				case 12: // Arc - Start, Center, Angle
				case 16: // Arc - Start, End, Radius
				case 19: // Arc - Center, Start, Length
					switch (ClickNum) {
						case 2:
							e.Graphics.DrawLine(extpen, extline);
							break;
						case 3:
							e.Graphics.DrawLine(extpen, new Line(p2, currentPosition));
							Method.GetArc(DrawIndex, p1, p2, currentPosition, out Arc drawArc);
							e.Graphics.DrawArc(extpen, drawArc);
							break;
					}
					break;
				case 21: // Circle - Center, Radius
				case 22: // Circle - Center, Diameter
					switch (ClickNum) {
						case 2:
							e.Graphics.DrawLine(extpen, extline);
							double r = p1.DistanceFrom(currentPosition);
							Circle circle = new Circle(p1, r);
							if (DrawIndex == 22)
								circle = new Circle(p1, r / 2);
							e.Graphics.DrawCircle(extpen, circle);
							break;
					}
					break;                    
				case 23: // Circle - 3-Points
					switch (ClickNum) {
						case 2:
							e.Graphics.DrawLine(extpen, extline);
							break;
						case 3:
							Circle c = Method.GetCircleWith3Point(p1, p2, currentPosition);
							e.Graphics.DrawCircle(extpen, c);
							break;
					}
					break;
				case 24: // Circle - 2-Points
					switch (ClickNum) {
						case 2:
							Circle c = Method.GetCircleWith2Point(p1, currentPosition);
							e.Graphics.DrawCircle(extpen, c);
							break;
					}
					break;
				case 31: // Full ellipse					
				case 32: // Elliptical Arc
					switch (ClickNum) {
						case 2:
						case 4:
							e.Graphics.DrawLine(extpen, extline);
							break;
						case 3:
							e.Graphics.DrawLine(extpen, extline);
							Ellipse ellipse = Method.GetEllipse(p1, p2, currentPosition);
							e.Graphics.DrawEllipse(extpen, ellipse);
							break;
						case 5:
							e.Graphics.DrawLine(extpen, extline);
							Ellipse elp = Method.GetEllipticalArc(p1, p2, p3, p4, currentPosition);
							e.Graphics.DrawEllipticalArc(pen, elp);
							break;
					}
					break;
			}

			switch (AnnotateIndex) {
				case 0:
					e.Graphics.DrawText(extpen, tempText);
					break;
			}
			#endregion            

			// Extended of modify
			if (activeModify) {
				switch (ModifyIndex) {
					case 0: // Copy
					case 1: // Move
					case 2: // Rotate
					case 3: // Mirror
					case 4: // Scale
						switch (ClickNum) {
							case 2:
								e.Graphics.ExtendedOfModify(extpen, ModifyIndex, entities, p1, currentPosition);
								break;
						}
						break;
					case 6: // Linear array
						e.Graphics.DrawExtendedOfLinearArray2D(extpen, entities,
							int.Parse(Value1),
							int.Parse(Value2),
							double.Parse(Value3),
							double.Parse(Value4),
							direction);
						break;
					case 7: // Circular array
						e.Graphics.DrawExtendedOfCircularArray2D(extpen, entities,
							p1,
							double.Parse(Value2),
							int.Parse(Value1),
							Value5);
						break;
				}				
			}

			// Draw zoom rect
			if (activeZoom && !activePan) {
				switch (ClickZoom) {
					case 2:
						LwPolyline rect = Method.PointToRect(PointToCartesian(firstCorner), currentPosition, out direction);
						e.Graphics.DrawLwPolyline(new Pen(Color.Red, 0), rect);
						break;
				}
			}

			// Select window
			if (!activeDrawing) {
				if (selectWindow) {
					switch (ClickNum) {
						case 2:
							SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, Color.LightBlue));
							SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, Color.LightGreen));
							LwPolyline polyline = Method.PointToRect(p1, currentPosition, out direction);

							switch (direction) {
								case 1: // Left to right
									e.Graphics.FillLwPolyline(brush1, polyline);
									break;
								case 2: // Right to left
									e.Graphics.FillLwPolyline(brush2, polyline);
									break;
							}
							e.Graphics.DrawLwPolyline(extpen, polyline);
							break;
					}
				}
			}
		}
		#endregion

		private void drawing_MouseMove(object sender, MouseEventArgs e) {
			currentPosition = PointToCartesian(e.Location);
			coordinate.Text = $"{currentPosition.X,0:F2}, {currentPosition.Y,0:F2}, {currentPosition.Z,0:F2}";
			
			if (!activeDrawing && !selectWindow) {
				Method.IsMouseOnEntity(entities, currentPosition, CursorRect(currentPosition), out EntityIndex);
			}
			
			if (activePan) {
				float dx = (float)(currentPosition.X - panPoint.X);
				float dy = (float)(currentPosition.Y - panPoint.Y);

				XScroll -= dx * ScaleFactor;
				YScroll += dy * ScaleFactor;

				SetScrollBarValues();
			}

			x1 = e.Location.X;
			x2 = drawing.ClientSize.Width - x1;
			y1 = e.Location.Y;
			y2 = drawing.ClientSize.Height - y1;

			if (entities.Count > 0) {
				if (entities[0] is LwPolyline)
					Text = (entities[0] as LwPolyline).Area.ToString();
			}

			drawing.Refresh();
		}

		private void drawing_MouseUp(object sender, MouseEventArgs e) {
			if (activePan) {
				activePan = false;
				ActiveCursor(cursorIndex, cursorSize);
				int dx = e.Location.X - startLocation.X;
				int dy = e.Location.Y - startLocation.Y;
								
				firstCorner = new System.Drawing.Point(firstCorner.X + dx, firstCorner.Y + dy);
			}
		}

		private void drawing_MouseWheel(object sender,MouseEventArgs e) {
			float cx = drawing.ClientSize.Width / 2.0f;
			float cy = drawing.ClientSize.Height / 2.0f;

			float w = (x1 < cx) ? Math.Min(x1, x2) * 2.0f : Math.Max(x1, x2) * 2.0f;
			float h = (y1 < cy) ? Math.Max(y1, y2) * 2.0f : Math.Min(y1, y2) * 2.0f;

			float scale = (e.Delta < 0) ? 1.25f : 1 / 1.25f;

			ScaleFactor *= scale;

			float width = w * scale;
			float height = h * scale;

			float wl = (w - width) / 2;
			float hl = (h - height) / 2;

			XScroll = XScroll * scale - PixelToMillimeters(wl);
			YScroll = YScroll * scale + PixelToMillimeters(hl);

			SetScrollBarValues();
		}

		#endregion

		#region " Custom function "
		// Convert system point to world point
		private Vector3 PointToCartesian(PointF point) {
			return new Vector3((PixelToMillimeters(point.X) + XScroll) / ScaleFactor,
				(PixelToMillimeters(drawing.Height - point.Y) - YScroll) / ScaleFactor);
		}

		// Convert pixels to millimeters
		private float PixelToMillimeters(float pixel) {
			return pixel * 25.4f / DPI;
		}

		private float MillimetersToPixels(float pixel) {
			return pixel / 25.4f * DPI;
		}

		private void CancelAll(int index=1) {
			DrawIndex = -1;
			AnnotateIndex = -1;
			tempText = new Text("");
			activeDrawing = false;
			activeSelection = true;
			activeModify = false;
			ActiveCursor(0, draw_cursorSize);
			ClickNum = 1;
			LwPolylineCloseStatus(index);
			tempEllipse.Clear();
			DeSelectAll();
			timer1.Enabled = false;
		}
		
		private void cancelBtn_Click(object sender, EventArgs e) {
			CancelAll();
		}

		// Get screen DPI
		private float DPI {
			get {
				using (var g = CreateGraphics())
					return g.DpiX;
			}
		}

		private void ActiveCursor(int index, float size) {
			Cursor cursor = Cursors.Default;
			if (index > 0)
				cursor = new Cursor(Method.SetCursor(index, MillimetersToPixels(size), Color.Red).GetHicon());
			drawing.Cursor = cursor;
		}

		private PointF[] CursorRect(Vector3 mousePosition) {
			float l = edit_cursorSize * 0.5f;
			float x = mousePosition.ToPointF.X;
			float y = mousePosition.ToPointF.Y;

			return new PointF[] {
				new PointF(x-1,y-1),
				new PointF(x+1,y-1),
				new PointF(x+1,y+1),
				new PointF(x-1,y+1)
			};
		}
		
		private void SetZoomWin(System.Drawing.Point firstCorner, System.Drawing.Point secondCorner) {
			Vector3 p1 = PointToCartesian(firstCorner);
			Vector3 p2 = PointToCartesian(secondCorner);

			float minX = Math.Min(p1.ToPointF.X, p2.ToPointF.X);
			float minY = Math.Min(p1.ToPointF.Y, p2.ToPointF.Y);

			float w = Math.Abs(firstCorner.X - secondCorner.X);
			float h = Math.Abs(firstCorner.Y - secondCorner.Y);

			float width = drawing.ClientSize.Width / w;
			float height = drawing.ClientSize.Height / h;

			float min = Math.Min(width, height);

			ScaleFactor *= min;

			float wl = (drawing.ClientSize.Width - w * min) / 2;
			float hl = (drawing.ClientSize.Height - h * min) / 2;

			XScroll = ScaleFactor * minX - PixelToMillimeters(wl);
			YScroll = -ScaleFactor * minY - PixelToMillimeters(hl);

			SetScrollBarValues();
		}

		private void SetZoomInOut(int index) {
			float scale = (index == 0) ? 1.25f : 1 / 1.25f;

			ScaleFactor *= scale;

			float width = drawing.ClientSize.Width * scale;
			float height = drawing.ClientSize.Height * scale;

			float wl = (drawing.ClientSize.Width - width) / 2;
			float hl = (drawing.ClientSize.Height - height) / 2;

			XScroll = XScroll * scale - PixelToMillimeters(wl);
			YScroll = YScroll * scale + PixelToMillimeters(hl);

			SetScrollBarValues();
		}

		private void ZoomEvents(int index) {
			switch (index) {
				case 0: // Zoom In
				case 1: // Zoom Out
					SetZoomInOut(index);
					break;
				case 2: // Zoom window
					activeZoom = true;
					if (activeDrawing) {
						cursorIndex = 1;
						cursorSize = 15;
					} else {
						cursorIndex = 0;
						cursorSize = 0;
					}
						ActiveCursor(1, draw_cursorSize);
					break;
			}
		}

		private void SetScrollBarValues() {
			float width = Math.Max(0, drawingSize.Width * ScaleFactor - PixelToMillimeters(drawing.ClientSize.Width)) + 50 * ScaleFactor;
			float height = Math.Max(0, drawingSize.Height * ScaleFactor - PixelToMillimeters(drawing.ClientSize.Height)) + 59 * ScaleFactor;

			hS.Maximum = (int)width;
			hS.Minimum = -(int)(50 * ScaleFactor);

			vS.Maximum = (int)(59 * ScaleFactor);
			vS.Minimum = -(int)height;

			try {
				hS.Minimum = (int)Math.Min(XScroll, hS.Minimum);
				hS.Maximum = (int)Math.Max(XScroll, hS.Maximum);
				vS.Minimum = (int)Math.Min(YScroll, vS.Minimum);
				vS.Maximum = (int)Math.Min(YScroll, vS.Maximum);

				hS.Value = (int)XScroll;
				vS.Value = (int)YScroll;
			} catch { }
			drawing.Refresh();
		}

		private void DeSelectAll() {
			foreach (EntityObject entity in entities)
				entity.DeSelect();
			drawing.Refresh();
		}

		private bool IsObjectSelected() {
			foreach (EntityObject entity in entities) {
				if (entity.IsSelected)
					return true;
			}
			return false;
		}
		#endregion

		#region " Graphics form components event "
		private void DrawBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			DrawIndex = drawPanel.Items.IndexOf(item);
			activeDrawing = true;
			ActiveCursor(1, draw_cursorSize);
		}

		private void ArcBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			DrawIndex = arcBtn.DropDownItems.IndexOf(item) + 10;
			activeDrawing = true;
			ActiveCursor(1, draw_cursorSize);
		}

		private void CircleBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			DrawIndex = circleBtn.DropDownItems.IndexOf(item) + 21;
			activeDrawing = true;
			ActiveCursor(1, draw_cursorSize);
		}

		private void EllipseBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			DrawIndex = ellipseBtn.DropDownItems.IndexOf(item) + 31;
			activeDrawing = true;
			ActiveCursor(1, draw_cursorSize);
		}

		private void hS_Scroll(object sender, ScrollEventArgs e) {
			XScroll = (sender as HScrollBar).Value;
			drawing.Refresh();
		}

		private void vS_Scroll(object sender, ScrollEventArgs e) {
			YScroll = (sender as VScrollBar).Value;
			drawing.Refresh();
		}

		private void ZoomBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			int index = zoomPanel.Items.IndexOf(item);
			ZoomEvents(index);
		}
		#endregion

		private void timer1_Tick(object sender, EventArgs e) {
			drawing.Refresh();
		}

		private void ModifyBtn_Click(object sender, EventArgs e) {
			var item = sender as RibbonButton;
			ModifyIndex = editPanel.Items.IndexOf(item);
			activeModify = true;
			ActiveCursor(2, edit_cursorSize);
			SetModifyPopup();

			if (IsObjectSelected())
				EnterBtn_Click(sender, null);

		}

		private ToolStripMenuItem toolitem;
		
		private void SetModifyPopup() {
			popup.Items.Clear();

			toolitem = new ToolStripMenuItem("Enter");
			toolitem.Click += new EventHandler(EnterBtn_Click);
			popup.Items.Add(toolitem);

			toolitem = new ToolStripMenuItem("Cancel");
			toolitem.Click += new EventHandler(cancelBtn_Click);
			popup.Items.Add(toolitem);
		}

		private void EnterBtn_Click(object sender, EventArgs e) {
			switch (ModifyIndex) {
				case 0: // Copy
				case 1: // Move
				case 2: // Rotate
				case 3: // Mirror
				case 4: // Scale
					activeSelection = false;
					ActiveCursor(1, draw_cursorSize);
					break;
				case 6: // Linear array
					timer1.Enabled = true;
					using (var inputarray=new InputLinearArray(this)) {
						var result = inputarray.ShowDialog();
						if (result == DialogResult.OK) {
							Method.LinearArray2D(entities, int.Parse(Value1), int.Parse(Value2), double.Parse(Value3), double.Parse(Value4), direction);
							drawing.Refresh();
							CancelAll();
						} else
							CancelAll();
					}
					break;
				case 7: // Circular array
					activeSelection = false;
					ActiveCursor(1, draw_cursorSize);
					ClickNum++;
					break;
				case 8: // Delete object
					Method.Delete(entities);
					CancelAll();
					break;
			}			
		}

		private void closeBoundary_Click(object sender, EventArgs e) {
			switch (DrawIndex) {
				case 3: // Line
					break;
				case 4: // LwPolyline
					CancelAll(2);
					break;
			}
		}

		private void annotate_Click(object sender,EventArgs e) {
			var item = sender as RibbonButton;
			AnnotateIndex = textPanel.Items.IndexOf(item);
			activeDrawing = true;
			ActiveCursor(1, draw_cursorSize);
		}

		private void LwPolylineCloseStatus(int index) {
			List<LwPolylineVertex> vertexes = new List<LwPolylineVertex>();
			foreach (LwPolylineVertex lw in tempPolyline.Vertexes)
				vertexes.Add(lw);
			if (vertexes.Count > 1) {
				switch (index) {
					case 1:
						entities.Add(new LwPolyline(vertexes, false));
						break;
					case 2:
						if (vertexes.Count > 2)
							entities.Add(new LwPolyline(vertexes, true));
						else
							entities.Add(new LwPolyline(vertexes, false));
						break;
				}
			}
			tempPolyline.Vertexes.Clear();
		}        
	}
}