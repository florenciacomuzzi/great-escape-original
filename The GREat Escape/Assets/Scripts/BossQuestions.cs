using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class BossQuestions : MonoBehaviour {

	const int NumOptions = 13;
	const int NumChoices = 4;

	//const int NumOptions = 13;
	public Text Question, Ans1, Ans2, Ans3;

	public int numWords = 20;//BookScript.bookControl.words.Length;
	//public char delim, delim2;
	public char delim1, delim2, delim3, delim4, delim5;


	//public string wrdTmp, defTmp, currQuestion;
	public string questionTemp, choice1, choice2, choice3, choice4, answer, currQuestion;
	public static SortedDictionary<string,string> questionsAnswers; // map of questions and answers. Q is key, A is value
	
	public List<string> answerOptions; //holds words to test on
	public List<string> keyList;
	public static List<string> currAnswers; //Array used to make sure answers aren't repeated
	public string[] multiple_choice; //Array of multiple choice options

	public string[] words;
	
	/*
	correct_index is used in ButtonPushed script when a player chooses an answer
	*/
	public static int correct_index;
	public static List<string> questionsUsed;
	
	// Use this for initialization
	void Start () {
		words = new string[] {
			"Question1 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice2", 
			"Question2 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 3",
			"Question3 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 3", 
			"Question4 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice2", 
			"Question5 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 4", 
			"Question6 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 4", 
			"Question7 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 4", 
			"Question8 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question9 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice2", 
			"Question10 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 4", 
			"Question11 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question12 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question13 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice 4", 
			"Question14 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice2", 
			"Question15 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question16 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question17 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice2", 
			"Question18 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question19 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1", 
			"Question20 is ? choice1 # choice2 $ choice 3 % choice 4 ! choice1"

		};


		questionsAnswers = new SortedDictionary<string,string> ();
		/*
		delim = ':';
		delim2 = '.';
		*/
		delim1 = '?';
		delim2 = '#';
		delim3 = '$';
		delim4 = '%';
		delim5 = '!';

	//	answerOptions = new List<string>[NumOptions];
		answerOptions = new List<string> ();
		questionsUsed = new List<string> ();
		currAnswers = new List<string> ();
		//parseCorrectWords ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//checks if index is in reviewIndicies
	public bool isInRevInd(int check){ 
		foreach (int i in BookScript.bookControl.reviewIndices) {
			if(i == check) { 
				return true;
			}
		}
		return false;
	}

	//checks if index is in reviewIndicies
	public bool isRevWord(string check){ 
		foreach (string i in BookScript.bookControl.reviewWords) {
			if(check == i) { 
				return true;
			}
		}
		return false;
	}


	public bool isQuesUsed(string check){
		foreach (string i in questionsUsed) {
			if (i == check)
				return true;
		}
		return false;
	}

	// sets map with questions and answers
	public void parseCorrectWords(int arrPos){

		//foreach (string str in BookScript.bookControl.words) {
		//foreach (string str in words) {
			/*
			if (isRevWord (str)) { // if in review, ignore it
				print("in set words for loop");
				//set review word in QA Map
				parseStr (str);
				questionsAnswers [answer] = questionTemp;
				continue; // go to next iteration
			}

			//only add words that weren't in review as non-correct answer options
			print("outside of set words for loop");
			parseStr (str);
			answerOptions.Add (questionTemp);
			print ("IN PARSEWORDS " + answer);

		}
		*/
		string str = words[arrPos];
		parseStr(str);
		//}
	}

	/*
	// breaks word,def string into separate word and definition
	public void parseStr(string toParse){
		int len = toParse.IndexOf (delim);
		int len2 = toParse.IndexOf (delim2);


		if (len > 0) {
			wrdTmp = toParse.Substring (0, len); // gets word up till the :
			defTmp = toParse.Substring(len+1, (len2-len+1) ); // get def up to .
			print(wrdTmp);
			print (defTmp);
		}

	}
	*/

	
	//version of parseStr for 4 mult choice 
	public void parseStr(string toParse){
		 print("in parseStr");
 	     int len = toParse.IndexOf (delim1);
 		 int len2 = toParse.IndexOf (delim2);
		 int len3 = toParse.IndexOf(delim3);
		 int len4 = toParse.IndexOf(delim4);
		 int len5 = toParse.IndexOf(delim5);

 		 if (len > 0) {	
      	      questionTemp = toParse.Substring (0, len); // gets question up to ?
      	      print("question is: " + questionTemp);
              choice1 = toParse.Substring(len+1, (len2 - len+1)); //gets first choice up to #
              choice2 = toParse.Substring(len2+1, (len3 - len2 +1)); // gets second choice up to $
              choice3 = toParse.Substring(len3+1, (len4 - len3 +1)); // gets second choice up to %
              choice4 = toParse.Substring(len4+1, (len5 - len4 +1)); // gets second choice up to !

		 	  answer = toParse.Substring(len4+1, (len5-len4+1)); // gets answer
		} 
	}

	public string getQuestionTempStr(){
		return questionTemp;
	}

	public int pickQuestion(){
		print("inside pickQuestion");
		//check level 
		int chosenQuestIndex = 1;//Random.Range(0,4);
		//check if question already used
		parseCorrectWords(chosenQuestIndex);
		return chosenQuestIndex;
	}
	

	/*
	public string pickQuestion(){
		//list of all keys in questionAnswers
		print("inside pickQuestion");
		//check level first, if level 1 question 1-5
		int quest = Random.Range(0,5);

		keyList = new List<string> (questionsAnswers.Keys);

		//assign element at a random index from 0 to size of keyList to the string randomKey (will be our question)
		//string randomKey = keyList[Random.Range(0, keyList.Count-1)];
		string randomKey = keyList[Random.Range(0, 3)];
		print ("randomkey chose:");
		print (randomKey);
		while (isQuesUsed (randomKey)) {
		  randomKey = keyList[Random.Range(0, keyList.Count-1)];
		}
		assignAnswers (questionsAnswers [randomKey]);  
		return randomKey;
	}
	*/

	public void assignAnswers(string correct){
		correct_index = Random.Range (0, NumChoices-1);
		print("The correct index inside bossquestions is:");
		print(correct_index);
	
		multiple_choice = new string[NumChoices];
		multiple_choice [correct_index] = correct;
		currAnswers.Add (correct);

		for (int i = 0; i <= NumChoices-1; i++) {
			if (i != correct_index) {
				/*
				int rand = Random.Range (0, answerOptions.Count - 1);
				string ans = answerOptions [rand];


				while (currAnswers.Contains (ans)) {
					rand = Random.Range (0, answerOptions.Count - 1);
					ans = answerOptions [rand];
				}
				//if (answerOptions [rand] != correct )
				multiple_choice [i] = ans;
				currAnswers.Add (ans);
				*/
				multiple_choice[i] = choice1;

			}
			else
				continue;
		
		}

		currAnswers.Clear ();

	}


	public bool isQuestionUsed(string word){ // check if question was already used
		foreach (string str in questionsAnswers.Keys) {
			if ( word == str ) {
				return true;
			}
		}
		return false;
	}

	//checks if player got question correct
	public bool checkAnswer(string playerAnswer){
		if (questionsAnswers [currQuestion].Equals (playerAnswer)) {
			return true;
		}
		return false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//parseCorrectWords ();
			pickQuestion();
		}
	}
}
