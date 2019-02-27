## Database structure
code-first migration was used

![image](https://user-images.githubusercontent.com/22146812/53501669-430e1a00-3ab5-11e9-847e-8c2fa5161a0f.png)

## Routes description
### Api
- Surveys

| Method | Route            | Description            |     
| ------ | ---------------- | ---------------------- | 
| GET    | /api/surveys     | get list of surveys    |    
| GET    | /api/survey/{id} | get survey by {id}     | 
| POST   | /api/survey      | add new survey         |   
| PUT    | /api/survey/{id} | update survey by {id}  |
| DELETE | /api/survey/{id} | delete survey by {id}  |


- Questions

| Method | Route              | Description              |     
| ------ | ------------------ | ------------------------ | 
| GET    | /api/questions     | get list of questions    |    
| GET    | /api/question/{id} | get question by {id}     | 
| POST   | /api/question      | add new question         |   
| PUT    | /api/question/{id} | update question by {id}  |
| DELETE | /api/question/{id} | delete question by {id}  |

- SurveyQuestions (uses SurveyQuestions table in db to work with questions specific survey)

| Method | Route                           | Description                                     |     
| ------ | ------------------------------- | ----------------------------------------------- | 
| POST   | /api/survey/{id}                | Add new question to survey                      |    
| GET    | /api/surveyquestions/{surveyId} | Get all questions of survey by {surveyId}       |
| DELETE | /api/surveyquestions/{surveyId} | Removes all questions from survey by {surveyId} |

- QuestionAnswers (uses QuestionAnswers table in db to work with answers with specific question)

| Method | Route                             | Description                                     |     
| ------ | --------------------------------- | ----------------------------------------------- | 
| POST   | /api/question/{id}                | Add new answer to a question                    |    
| POST   | /api/question/multiple/{id}       | Add list of answers to a question               |
| GET    | /api/questionanswers/{questionId} | Get all ansers of a question                    |

### MVC
| Route                | Description                                                  |     
| -------------------- | ------------------------------------------------------------ | 
| /surveys/index       | shows list of surveys                                        |   
| /surveys/detail/{id} | shows detail about survey with id = {id}                     | 
| /questions/new/{id}  | allows user to create new question for survey with id = {id} |   
| /surveys/new         | allows user to create new survey                             |

## What you can do
You can see all surveys
![image](https://user-images.githubusercontent.com/22146812/53448005-1b6c7280-3a1f-11e9-9db9-4958f5e9d707.png)
By clicking 'Create new survey' button you can create new survey
![image](https://user-images.githubusercontent.com/22146812/53448131-5a022d00-3a1f-11e9-9277-4aa03f922a45.png)
![image](https://user-images.githubusercontent.com/22146812/53448160-6edec080-3a1f-11e9-84d7-9e1942545636.png)
If you don't fill data into all fields you won't create a survey (there is validation)
![image](https://user-images.githubusercontent.com/22146812/53448257-a188b900-3a1f-11e9-9cfe-c5c594703039.png)
After creating a survey you can see it in list of surveys
![image](https://user-images.githubusercontent.com/22146812/53448336-d432b180-3a1f-11e9-8c14-5baf5d9319f0.png)
You can check details of the specific survey by choosing it
![image](https://user-images.githubusercontent.com/22146812/53448408-004e3280-3a20-11e9-823d-e2e79efa3d90.png)
Details of specific survey
![image](https://user-images.githubusercontent.com/22146812/53448464-1fe55b00-3a20-11e9-8327-5d405e211612.png)
You can create questions for survey by clicking 'Add new question' button
![image](https://user-images.githubusercontent.com/22146812/53448498-3390c180-3a20-11e9-801a-c0f55934fb49.png)
Form for creating new question
![image](https://user-images.githubusercontent.com/22146812/53448585-6d61c800-3a20-11e9-8513-26e1eb4e37e7.png)
As well there is validation
![image](https://user-images.githubusercontent.com/22146812/53448607-823e5b80-3a20-11e9-8deb-61bf57092121.png)
You have to create at least one answer
![image](https://user-images.githubusercontent.com/22146812/53448677-abf78280-3a20-11e9-89bc-bcb6a58ef745.png)
You can create new answer by entering text into available field and clicking add button
![image](https://user-images.githubusercontent.com/22146812/53448704-bd408f00-3a20-11e9-8102-9aee3b42862b.png)
After clicking 'Save' button question will be created
![image](https://user-images.githubusercontent.com/22146812/53448763-dba68a80-3a20-11e9-9119-b6b698f74ffc.png)
Some more examples
![image](https://user-images.githubusercontent.com/22146812/53448866-20322600-3a21-11e9-928f-e8ba095319c6.png)
![image](https://user-images.githubusercontent.com/22146812/53448883-2cb67e80-3a21-11e9-8232-7325b68f6108.png)
As you can see there is viewCount which looks like an eye. It's value increments each time someone enters survey detail page
![image](https://user-images.githubusercontent.com/22146812/53448939-4eb00100-3a21-11e9-9258-b30de088876e.png)

## Unit testing
xUnit is used to create unit tests for api.
There is additional DbContext (called: TestApplicationContext) created for testing. It has the same schema as the main context
![image](https://user-images.githubusercontent.com/22146812/53499466-13f5a980-3ab1-11e9-94f7-67102946d6a2.png)
