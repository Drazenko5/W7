SELECT c1.Name,c1.Phone,c1.Email FROM CONTACT c1, CONTACT c2
WHERE c1.Phone=c2.Phone AND c1.Created_By=[JOHN_ID] AND c2.Created_By=[MARY_ID]