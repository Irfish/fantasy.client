// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: user_enter.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Pb {

  /// <summary>Holder for reflection information generated from user_enter.proto</summary>
  public static partial class UserEnterReflection {

    #region Descriptor
    /// <summary>File descriptor for user_enter.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserEnterReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChB1c2VyX2VudGVyLnByb3RvEgJwYiIeCgxDdHNVc2VyRW50ZXISDgoGdXNl",
            "cklkGAEgASgDImsKDFN0Y1VzZXJFbnRlchIOCgZ1c2VySWQYASABKAMSDAoE",
            "bmFtZRgCIAEoCRIOCgZyb29tSWQYAyABKAMSDwoHY2hhaXJJZBgEIAEoBRIM",
            "CgRnb2xkGAUgASgDEg4KBmhlYWRJZBgGIAEoAyIvCgxDdHNVc2VyTGVhdmUS",
            "DgoGdXNlcklkGAEgASgDEg8KB2NoYWlySWQYAiABKAUiPwoMU3RjVXNlckxl",
            "YXZlEg4KBnVzZXJJZBgBIAEoAxIOCgZyb29tSWQYAyABKAMSDwoHY2hhaXJJ",
            "ZBgEIAEoBWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Pb.CtsUserEnter), global::Pb.CtsUserEnter.Parser, new[]{ "UserId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Pb.StcUserEnter), global::Pb.StcUserEnter.Parser, new[]{ "UserId", "Name", "RoomId", "ChairId", "Gold", "HeadId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Pb.CtsUserLeave), global::Pb.CtsUserLeave.Parser, new[]{ "UserId", "ChairId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Pb.StcUserLeave), global::Pb.StcUserLeave.Parser, new[]{ "UserId", "RoomId", "ChairId" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class CtsUserEnter : pb::IMessage<CtsUserEnter> {
    private static readonly pb::MessageParser<CtsUserEnter> _parser = new pb::MessageParser<CtsUserEnter>(() => new CtsUserEnter());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CtsUserEnter> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Pb.UserEnterReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserEnter() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserEnter(CtsUserEnter other) : this() {
      userId_ = other.userId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserEnter Clone() {
      return new CtsUserEnter(this);
    }

    /// <summary>Field number for the "userId" field.</summary>
    public const int UserIdFieldNumber = 1;
    private long userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CtsUserEnter);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CtsUserEnter other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId != 0L) hash ^= UserId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(UserId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(UserId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CtsUserEnter other) {
      if (other == null) {
        return;
      }
      if (other.UserId != 0L) {
        UserId = other.UserId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            UserId = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class StcUserEnter : pb::IMessage<StcUserEnter> {
    private static readonly pb::MessageParser<StcUserEnter> _parser = new pb::MessageParser<StcUserEnter>(() => new StcUserEnter());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StcUserEnter> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Pb.UserEnterReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserEnter() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserEnter(StcUserEnter other) : this() {
      userId_ = other.userId_;
      name_ = other.name_;
      roomId_ = other.roomId_;
      chairId_ = other.chairId_;
      gold_ = other.gold_;
      headId_ = other.headId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserEnter Clone() {
      return new StcUserEnter(this);
    }

    /// <summary>Field number for the "userId" field.</summary>
    public const int UserIdFieldNumber = 1;
    private long userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 2;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "roomId" field.</summary>
    public const int RoomIdFieldNumber = 3;
    private long roomId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long RoomId {
      get { return roomId_; }
      set {
        roomId_ = value;
      }
    }

    /// <summary>Field number for the "chairId" field.</summary>
    public const int ChairIdFieldNumber = 4;
    private int chairId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ChairId {
      get { return chairId_; }
      set {
        chairId_ = value;
      }
    }

    /// <summary>Field number for the "gold" field.</summary>
    public const int GoldFieldNumber = 5;
    private long gold_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Gold {
      get { return gold_; }
      set {
        gold_ = value;
      }
    }

    /// <summary>Field number for the "headId" field.</summary>
    public const int HeadIdFieldNumber = 6;
    private long headId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long HeadId {
      get { return headId_; }
      set {
        headId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StcUserEnter);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StcUserEnter other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      if (Name != other.Name) return false;
      if (RoomId != other.RoomId) return false;
      if (ChairId != other.ChairId) return false;
      if (Gold != other.Gold) return false;
      if (HeadId != other.HeadId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId != 0L) hash ^= UserId.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (RoomId != 0L) hash ^= RoomId.GetHashCode();
      if (ChairId != 0) hash ^= ChairId.GetHashCode();
      if (Gold != 0L) hash ^= Gold.GetHashCode();
      if (HeadId != 0L) hash ^= HeadId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(UserId);
      }
      if (Name.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Name);
      }
      if (RoomId != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(RoomId);
      }
      if (ChairId != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ChairId);
      }
      if (Gold != 0L) {
        output.WriteRawTag(40);
        output.WriteInt64(Gold);
      }
      if (HeadId != 0L) {
        output.WriteRawTag(48);
        output.WriteInt64(HeadId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(UserId);
      }
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (RoomId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(RoomId);
      }
      if (ChairId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ChairId);
      }
      if (Gold != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Gold);
      }
      if (HeadId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(HeadId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StcUserEnter other) {
      if (other == null) {
        return;
      }
      if (other.UserId != 0L) {
        UserId = other.UserId;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.RoomId != 0L) {
        RoomId = other.RoomId;
      }
      if (other.ChairId != 0) {
        ChairId = other.ChairId;
      }
      if (other.Gold != 0L) {
        Gold = other.Gold;
      }
      if (other.HeadId != 0L) {
        HeadId = other.HeadId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            UserId = input.ReadInt64();
            break;
          }
          case 18: {
            Name = input.ReadString();
            break;
          }
          case 24: {
            RoomId = input.ReadInt64();
            break;
          }
          case 32: {
            ChairId = input.ReadInt32();
            break;
          }
          case 40: {
            Gold = input.ReadInt64();
            break;
          }
          case 48: {
            HeadId = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  public sealed partial class CtsUserLeave : pb::IMessage<CtsUserLeave> {
    private static readonly pb::MessageParser<CtsUserLeave> _parser = new pb::MessageParser<CtsUserLeave>(() => new CtsUserLeave());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<CtsUserLeave> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Pb.UserEnterReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserLeave() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserLeave(CtsUserLeave other) : this() {
      userId_ = other.userId_;
      chairId_ = other.chairId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public CtsUserLeave Clone() {
      return new CtsUserLeave(this);
    }

    /// <summary>Field number for the "userId" field.</summary>
    public const int UserIdFieldNumber = 1;
    private long userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    /// <summary>Field number for the "chairId" field.</summary>
    public const int ChairIdFieldNumber = 2;
    private int chairId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ChairId {
      get { return chairId_; }
      set {
        chairId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as CtsUserLeave);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(CtsUserLeave other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      if (ChairId != other.ChairId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId != 0L) hash ^= UserId.GetHashCode();
      if (ChairId != 0) hash ^= ChairId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(UserId);
      }
      if (ChairId != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(ChairId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(UserId);
      }
      if (ChairId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ChairId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(CtsUserLeave other) {
      if (other == null) {
        return;
      }
      if (other.UserId != 0L) {
        UserId = other.UserId;
      }
      if (other.ChairId != 0) {
        ChairId = other.ChairId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            UserId = input.ReadInt64();
            break;
          }
          case 16: {
            ChairId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class StcUserLeave : pb::IMessage<StcUserLeave> {
    private static readonly pb::MessageParser<StcUserLeave> _parser = new pb::MessageParser<StcUserLeave>(() => new StcUserLeave());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StcUserLeave> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Pb.UserEnterReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserLeave() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserLeave(StcUserLeave other) : this() {
      userId_ = other.userId_;
      roomId_ = other.roomId_;
      chairId_ = other.chairId_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StcUserLeave Clone() {
      return new StcUserLeave(this);
    }

    /// <summary>Field number for the "userId" field.</summary>
    public const int UserIdFieldNumber = 1;
    private long userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    /// <summary>Field number for the "roomId" field.</summary>
    public const int RoomIdFieldNumber = 3;
    private long roomId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long RoomId {
      get { return roomId_; }
      set {
        roomId_ = value;
      }
    }

    /// <summary>Field number for the "chairId" field.</summary>
    public const int ChairIdFieldNumber = 4;
    private int chairId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ChairId {
      get { return chairId_; }
      set {
        chairId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StcUserLeave);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StcUserLeave other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      if (RoomId != other.RoomId) return false;
      if (ChairId != other.ChairId) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId != 0L) hash ^= UserId.GetHashCode();
      if (RoomId != 0L) hash ^= RoomId.GetHashCode();
      if (ChairId != 0) hash ^= ChairId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (UserId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(UserId);
      }
      if (RoomId != 0L) {
        output.WriteRawTag(24);
        output.WriteInt64(RoomId);
      }
      if (ChairId != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(ChairId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(UserId);
      }
      if (RoomId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(RoomId);
      }
      if (ChairId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ChairId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StcUserLeave other) {
      if (other == null) {
        return;
      }
      if (other.UserId != 0L) {
        UserId = other.UserId;
      }
      if (other.RoomId != 0L) {
        RoomId = other.RoomId;
      }
      if (other.ChairId != 0) {
        ChairId = other.ChairId;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            UserId = input.ReadInt64();
            break;
          }
          case 24: {
            RoomId = input.ReadInt64();
            break;
          }
          case 32: {
            ChairId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
