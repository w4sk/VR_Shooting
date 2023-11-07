using UnityEngine;

public class LookRotation : MonoBehaviour
{

	private void Update()
	{
        GameObject target = GameObject.FindWithTag("Player");
		// 対象物と自分自身の座標からベクトルを算出
		Vector3 vector3 = target.transform.position - this.transform.position;
		// もし上下方向の回転はしないようにしたければ以下のようにする。
		vector3.y = 0f;

		// Quaternion(回転値)を取得
		Quaternion quaternion = Quaternion.LookRotation(vector3);
        // Vector3 eulerAngles = quaternion.eulerAngles;
        // eulerAngles.y -= 90.0f;
        // quaternion = Quaternion.Euler(eulerAngles);
		// 算出した回転値をこのゲームオブジェクトのrotationに代入
		this.transform.rotation = quaternion;


        if(SelectMotionController.AvatarSelectComplete)
        {
            LookRotation lookRotation = this.GetComponent<LookRotation>();
            lookRotation.enabled = false;
        }
	}
}