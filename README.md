## Routes
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
