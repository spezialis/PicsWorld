// DISTANCE SENSOR
//const int distPin0 = A0;
//int distPin0Val;
//float newDistPin0Val;

#include <SharpIR.h>
#define ir A0
#define model 1080

SharpIR SharpIR(ir, model);

// PHOTOCELLS
const int photoPin1 = A1;
const int photoPin2 = A2;
const int photoPin3 = A3;
const int photoPin4 = A4;

int photoPin1Val;
int photoPin2Val;
int photoPin3Val;
int photoPin4Val;

void setup() {
  Serial.begin(9600);
}

void loop() {
  // DISTANCE
  // distPin0Val = analogRead(distPin0);
  // newDistPin0Val = map(distPin0Val, 600, 0, 0, 20);

  int dis = SharpIR.distance();

  // PHOTOCELL
  photoPin1Val = analogRead(photoPin1);
  photoPin2Val = analogRead(photoPin2);
  photoPin3Val = analogRead(photoPin3);
  photoPin4Val = analogRead(photoPin4);

  // SERIAL PRINTS
  //  Serial.print(distPin0Val);
  //  Serial.print(newDistPin0Val);

  //
  Serial.print(dis);
  Serial.print("\t");

  // WALL 1
  Serial.print(photoPin4Val);
  Serial.print("\t");

  // WALL 2
  Serial.print(photoPin3Val);
  Serial.print("\t");

  // WALL 3
  Serial.print(photoPin1Val);
  Serial.print("\t");

  // WALL 4
  Serial.println(photoPin2Val);

  delay(500);
}

//void map(value, istart, istop, ostart, ostop) {
//  return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
//}
