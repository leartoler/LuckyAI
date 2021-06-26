using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
	private KeywordRecognizer keywordRecognizer;
	private Dictionary<string, Action> actions = new Dictionary<string, Action>();

void Start()
{
	actions.Add("forward", Forward);
	actions.Add("up", Up);
	actions.Add("down", Down);
	actions.Add("back", Back);

	keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray()); //SLista de palabras que reconoce. Las traducira a actions keys.
	keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
	keywordRecognizer.Start();
}

private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
{
	Debug.Log(speech.text);
	actions[speech.text].Invoke();
}

//poner en esta parte los efectos de las particulas a cambiar. Primera prueba solo para mover al personaje

private void Forward()
{
	transform.Translate(1,0,0); //buscar las variables para cada uno de los efectos de particulas
}

private void Back()
{
	transform.Translate(-1,0,0); //buscar las variables para cada uno de los efectos de particulas
}

private void Up()
{
	transform.Translate(1,0,0); //buscar las variables para cada uno de los efectos de particulas
}

private void Down()
{
	transform.Translate(-1,0,0); //buscar las variables para cada uno de los efectos de particulas
}

}
