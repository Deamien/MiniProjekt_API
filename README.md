GET endpoints:


/people  lists the people

/people/{id}/interests/urls  lists urls based on the personid

/people/{id}/interests  lists interests based on the personid

/urls  lists the urls

/interests  lists the interests




POST endpoints:


JSON Input

/people/{id}/interests  posts a new interest based on the personid
/people/{personId}/interests/{interestId}/urls  posts a new urls based on the personid and interestid
/persons/{personId}/interests/{interestId} post connects a person to an interest


![Er Diagram Mini_API](https://github.com/Deamien/MiniProjekt_API/assets/25642231/99006145-e909-409c-a5ee-9c6a98b48e54)
![UML Diagram Mini_API](https://github.com/Deamien/MiniProjekt_API/assets/25642231/c5b74ecd-d565-4fa8-a1c6-ac373e3e7bfb)
