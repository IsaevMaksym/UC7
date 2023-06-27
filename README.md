Tests description:
StudentConverterTests contains tests that cover the StudentConverter service. It contains next test cases:
	Case 1: One student passed, age 21+, grade 90+. Expected result: Student: field should be the same and HonorRoll = true;
	Case 2: One student passed, age up to 21, grade 90+. Expected result: Student: field should be the same and Exceptional = true;
	Case 3: (Two scenarios. One student passed, grade = 71, grade = 90(second scenario). Expected result: Student: field should be the same and Passed = true in both scenarios;
	Case 4: One student passed, a grade was randomly selected between 71 and 90 (inclusive). Expected result: Student: field should be the same and Passed = true;
	Case 5: One student passed, a grade is randomly selected and less than 70. Expected result: Student: field should be the same and Passed = false;
	Case 6: Empty array is passed. Expected result: empty array;
	Case 7: Null instead of array is passed. Expected result: exception is thrown;
	Case 8: Array with Null student is passed. Expected result: exception is thrown.
	
PlayerAnalyzerTests contains tests that cover the PlayerAnalyzer service. It contains next test cases:
	Case 1: Empty list is passed. Expected result: Zero is returned.
	Case 2: One Player passed, age 15, experience 3, skills 333. Expected result: 67.5 returned;
	Case 3: One Player passed, age 25, experience 5, skills 222. Expected result: 250 returned;
	Case 4: One Player passed, age 35, experience 15, skills 444. Expected result: 2520 returned;
	Case 5: One Player passed, skills are Null. Expected result: exception is thrown;
	Case 6: Three players passed with different parameters. Expected result: 1130 returned.