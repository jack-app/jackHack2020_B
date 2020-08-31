module.exports = function(req, res) {
    var NCMB = require('ncmb');
    var ncmb = new NCMB("c9ec36f7b10420d1bb067049f0673bd572bd6dbb0f9e871585ad53d62241e59b", "6395c170b01f438a006bf84aaa4384a0e7bbafccf21cb8974018fdaf6bd711ad")

    var planID = req.get("planid");
    var Item = ncmb.DataStore('Plan');

    Item.fetchById(planID)
        .then(function(result){

            var userArray = result.get("userList");
            var UserItem = ncmb.DataStore("User");
            UserItem.in("objectId", userArray)
                    .order("createDate")
                    .fetchAll()
                    .then(function(results){
                        var itemList = results.map(x => x.get("MuscleItemID"));
                        var newItemList = [];
                        for (let index = 0; index < itemList.length; index++) {
                            newItemList.push(itemList[(index + 1) % itemList.length]);
                        }

                        for (let index = 0; index < results.length; index++) {
                            UserItem.fetchById(results[index].get("objectId"))
                                    .then(function(rslt){
                                        rslt.set("MuscleItemID", newItemList[index]);
                                        rslt.update()
                                              .then(function(r){
                                                if (index + 1 == results.length){
                                                    res.send("POST data successfully!");
                                                }
                                              })
                                              .catch(function(error){
                                                  req.status(500).json({error: error});
                                              });
                                    })
                                    .catch(function(error){
                                        req.status(500).json({error: error});
                                    });
                        }
                    })
                    .catch(function(error){
                        req.status(500).json({error: error});
                    });
        })
        .catch(function(error){
            res.status(500).json({Error: error});
        });
}
