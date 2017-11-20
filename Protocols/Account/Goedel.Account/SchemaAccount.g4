﻿Using Goedel.Cryptography.Jose 
Namespace Goedel.Account

AccountProtocol Protocol ||Mesh/Account Service
		|The Mesh/Account Service is used to manage accounts. All operations
		|are regarded as privileged and will require appropriate access controls.

    AccountService Service "_mmmaccount._tcp" "mmmaccount"
		|Every Mesh/Account Service transaction consists of exactly one
		|request followed by exactly one response.

	AccountRequest Structure 
		External Goedel.Protocol.Request
			|Base class for all request messages.

	AccountResponse Structure 
		External Goedel.Protocol.Response		
			|Base class for all response messages. Contains only the
			|status code and status description fields.
			|
			|A service MAY return either the response message specified
			|for that transaction or any parent of that message. 
			|Thus the RecryptResponse message MAY be returned in response 
			|to any request.

	Section			||Imported Objects
		|None

	Section			||Common classes
		|The following classes are referenced at multiple points in the protocol.

	AccountData Structure 					|The data associated with an account
		AccountId String					|The account identifier
		Created DateTime					|Date and time that the account identifier was created.
		Status String						|Account status
		MeshUDF String						|Fingerprint of the user's mesh profile
		Portal Multiple String 				|Mesh Portal identifier
		Entries Multiple AccountDataEntry	|Service specific data

	AccountDataEntry Structure 				|Superclass for all account data entry objects
		Abstract

	Section 2 "Utility Transactions"

    Hello Transaction						||Report service and version information. 
			|The Hello transaction provides a means of determining which protocol
			|versions, message encodings and transport protocols are supported by
			|the service.
		Request AccountHelloRequest HelloRequest
		Response AccountHelloResponse HelloResponse

	Admin TransactionSet						||Administration Transactions

		Create Transaction						|Create new account
			Request CreateRequest AccountRequest
				Data AccountData				|Describes the account to be created
			Response CreateResponse AccountResponse
				UDF String						|Unique identifier of the account

		Delete Transaction						||Delete an account
			Request DeleteRequest AccountRequest
				AccountId String				|The account to delete
			Response DeleteResponse AccountResponse

		Update Transaction						||Update an account profile
			Request UpdateRequest AccountRequest
				Data AccountData				|The account to update
			Response UpdateResponse AccountResponse

		Get Transaction							||Create new account
			Request GetRequest AccountRequest
				Data AccountData				|The account to fetch
			Response GetResponse AccountResponse
				Data AccountData				|Describes the account (if found)
