�������� �������

��������� ������� "��������"

����:
������� �������� �� ���������� �������, � ������� ����������� ������ ������������ �������� �� ������� �������������� "��������".


��������/��������� ���������� ���������� ��������� �������:

- ��������� � ������� 3-4 ������, ������� ��� ������� ������ ����������� � �������� ������� �������� �������.
```
Person -> Student

Person -> Employee -> Teacher
```
- ������� ���� �������� ��������� IMyCloneable ��� ���������� ������� "��������".
- ������� ����������� ������������ ������� ��� ������� �� ���� �������, ��������� ������ ������������ �������������.
- ��������� ����� ��� �������� ��������� ��� ������������ ������� ������������.
- �������� � ������� ������ ���������� ������������ ���������� ICloneable � ����������� ��� ���������� ����� ��� ��������� ������.
- �������� �����: ����� ������������ � ���������� � ������� �� �����������: IMyCloneable � ICloneable.

	- IMyCloneable:
		- ������������:
			- ���������� ���� �������� ��� ������������
			- ��� ������������ ���������� ��������������� �������
		- ����������:
			- ���������� ������������� ��������������
			- ���������� ��������������
	- ICloneable:
		- ������������:
			- �����������
			- ����������� ���������� ��� �������� ������������
			- �������������
		- ����������:
			- ������������� ���������� �����
			- �� ����������� ��� ������������ (�������� ��� ������������� ������������)
			- �� ������������ ����������