using Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public static class MongoDbConfig
{
    public static void Configure()
    {
        // Kiểm tra xem SessionModel đã được đăng ký chưa
        if (!BsonClassMap.IsClassMapRegistered(typeof(SessionModel)))
        {
            BsonClassMap.RegisterClassMap<SessionModel>(cm =>
            {
                cm.AutoMap(); // Map tự động các trường trùng tên

                // 1. Cấu hình ID
                // Map SessionId thành "_id" trong MongoDB
                // Và lưu GUID dưới dạng String (để dễ đọc trong Compass)
                cm.MapIdMember(c => c.SessionId)
                  .SetSerializer(new GuidSerializer(BsonType.String));

                // 2. Cấu hình các trường GUID khác (AccountId)
                // Cũng lưu dạng String thay vì Binary (Standard)
                cm.MapMember(c => c.AccountId)
                  .SetSerializer(new GuidSerializer(BsonType.String));

                // 3. Cấu hình Enum (LoginMethod)
                // Lưu dưới dạng số (1, 2) thay vì chuỗi ("Mobile", "Web")
                cm.MapMember(c => c.LoginMethod)
                  .SetSerializer(new EnumSerializer<LoginType>(BsonType.Int32));
                
                // Nếu muốn bỏ qua trường nào không lưu vào DB
                // cm.UnmapMember(c => c.AccessToken);
                
                // Cấu hình bỏ qua các trường null khi lưu (giúp tiết kiệm dung lượng)
                cm.SetIgnoreExtraElements(true); 
            });
        }
    }
}